using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Vshope.Application.Auth.Abstr;
using Vshope.Application.Common.Abstr;
using Vshope.Application.Util.Abstr;
using Vshope.Common;
using Vshope.Common.Exception;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Auth;
using Vshope.Model.Model.Auth;
using Vshope.Model.Model.Dict;

namespace Vshope.Application.Auth
{
    public class AuthService: IAuthService
    {
        private readonly ContextApp _context;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IScopeService _scopeService;

        public AuthService(ContextApp context, IMapper mapper, IScopeService scopeService, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _scopeService = scopeService;
        }

        #region Register

        public async Task<User> RegisterNoSave(UserRegisterDTO dto)
        {
            var user = await _context.Users.WhereIsNotDeleted().FirstOrDefaultAsync(
                u => u.UserName == dto.UserName || u.Email == dto.Email);
            if (user == null)
            {
                var passwordHash = PasswordHelper.GetPasswordHash(dto.Password);
                var utcNow = _scopeService.RequestDateTimeOffsetUtc;
                var role = await _context.Roles.FirstAsync(r => r.Name == UserRoleNames.USER);
                user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PasswordHash = passwordHash,
                    StatusId = (int)UserStatusEnum.Created,
                    RegistrationDate = utcNow,
                    Role = role,
                    Company = dto.Company
                };
                var newUser = (await _context.Users.AddAsync(user)).Entity;
                return newUser;
            }

            throw new BusinessLogicException(ExceptionCodes.BL_CODE_USER_ALREADY_EXIST);
        }

        public async Task RegisterSendEmail(User newUser)
        {
            var paramDict = new Dictionary<string, string>();
            paramDict.Add("name", newUser.UserName);
            paramDict.Add("clientDomain", ConstantsApp.CLIENT_DOMAIN);
            var code = GetCode(newUser.Id, newUser.UserName);
            paramDict.Add("code", code);
            await _emailService.SendEmailAsync(newUser.Email, EmailTemplateEnum.UserRegistrationCreatedEmail,
                paramDict);
        }

        public Task<UserDTO> ResetPassword(string code, string newPassword)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Login

        public async Task<UserLoginResponseDTO> Login(UserLoginDTO dto)
        {
            var user = await _context.Users.WhereIsNotDeleted()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user != null
                && PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash))
            {
                //todo think about BL_CODE_USER_NOT_CONFIRMED exception
                /*if (user.StatusId < (int) UserStatusEnum.Confirmed)
                {
                    throw new BusinessLogicException(ExceptionCodes.BL_CODE_USER_NOT_CONFIRMED);
                }*/
                var jwtToken = GetJwt(user);
                var refreshToken = GetRefreshToken(user.Id, user.UserName, user.Role?.Name);
                var response = new UserLoginResponseDTO
                {
                    AccessToken = jwtToken,
                    UserName = user.UserName,
                    Role = user.Role?.Name,
                    CompanyId = user.CompanyId,
                    RefreshToken = refreshToken
                };
                return response;
            }

            throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
        }
        
        #endregion

        #region ConfirmEmail

        public async Task<UserDTO> ConfirmEmail(string code)
        {
            var id = ValidateCodeAndGetUser(code);
            var user = await _context.Users.WhereIsNotDeleted(x => x.Id == id).FirstAsync();
            if (user.StatusId != (int)UserStatusEnum.Confirmed)
            {
                user.StatusId = (int)UserStatusEnum.Confirmed;
                await _context.SaveChangesAsync();

                var userDto = _mapper.Map<User, UserDTO>(user);

                var paramDict = new Dictionary<string, string>();
                paramDict.Add("name", user.UserName);
                paramDict.Add("clientDomain", ConstantsApp.CLIENT_DOMAIN);
                await _emailService.SendEmailAsync(user.Email, EmailTemplateEnum.UserRegistrationConfirmedEmail,
                    paramDict);
                return userDto;
            }

            return null;
        }
       
        #endregion

        #region ResetPassword

        //public async Task<MobileUserDTO> ResetPasswordMobile(string code, string newPassword)
        //{
        //    var id = ValidateCodeAndGetUser(code);
        //    var user = await _context.MobileUsers.WhereIsNotDeleted(x => x.Id == id).FirstAsync();
        //    var passwordHash = PasswordHelper.GetPasswordHash(newPassword);
        //    user.PasswordHash = passwordHash;
        //    await _context.SaveChangesAsync();
        //    var userDto = _mapper.Map<MobileUser, MobileUserDTO>(user);

        //    var paramDict = new Dictionary<string, string>();
        //    paramDict.Add("name", userDto.Name);
        //    paramDict.Add("clientDomain", ConstantsApp.CLIENT_DOMAIN);
        //    await _emailService.SendEmailAsync(user.Email, EmailTemplateEnum.MobileUserResetPasswordDoneEmail,
        //        paramDict);

        //    return userDto;
        //}

        //public async Task ResetPasswordMobileInit(string userName)
        //{
        //    var user = await _context.MobileUsers.FirstOrDefaultAsync(x => x.UserName == userName);
        //    if (user == null)
        //    {
        //        throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
        //    }

        //    var userDto = _mapper.Map<MobileUser, MobileUserDTO>(user);

        //    var paramDict = new Dictionary<string, string>();
        //    paramDict.Add("name", userDto.Name);
        //    paramDict.Add("clientDomain", ConstantsApp.CLIENT_DOMAIN);
        //    var code = GetCode(user.Id, user.UserName);
        //    paramDict.Add("code", code);
        //    await _emailService.SendEmailAsync(user.Email, EmailTemplateEnum.MobileUserResetPasswordEmail,
        //        paramDict);
        //}

        #endregion

        #region Refresh token

        public async Task<UserLoginResponseDTO> RefreshToken(string jwtToken, string refreshToken)
        {
            var id = ValidateRefreshTokenAndGetUser(refreshToken);
            var idFromJwt = ValidateJwtBigExpireAndGetUser(jwtToken);
            var user = await _context.Users.WhereIsNotDeleted(x => x.Id == id).Include(x => x.Role).FirstAsync();
            var newJwtToken = GetJwt(user);
            var newRefreshToken = GetRefreshToken(user.Id, user.UserName, user.Role?.Name);
            if (id == idFromJwt)
            {
                var response = new UserLoginResponseDTO
                {
                    AccessToken = newJwtToken,
                    UserName = user.UserName,
                    Role = user.Role?.Name,
                    RefreshToken = newRefreshToken
                };
                return response;
            }

            throw new BusinessLogicException(ExceptionCodes.AUTH_REFRESH_TOKEN_INCORRECT);
        }
       
        #endregion

        #region Service Methods

        private string GetJwt(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
                new Claim(ClaimsIdentity.DefaultIssuer, user.Id.ToString()),
                new Claim(ClaimTypes.Actor, user.CompanyId == null ? "" : user.CompanyId.ToString())
            };
            var id = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = _scopeService.RequestDateTimeUtc;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                ConstantsApp.AUTH_ISSUER,
                ConstantsApp.AUTH_AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(ConstantsApp.AUTH_JWT_LIFETIME)),
                signingCredentials: new SigningCredentials(ConstantsApp.GetAuthJwtSymmetricKeyBytes(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        
        private string GetCode(int id, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultIssuer, id.ToString())
            };
            var now = _scopeService.RequestDateTimeUtc;
            var jwt = new JwtSecurityToken(
                ConstantsApp.AUTH_ISSUER,
                ConstantsApp.AUTH_AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(ConstantsApp.AUTH_CODE_LIFETIME)),
                signingCredentials: new SigningCredentials(ConstantsApp.GetAuthCodeSymmetricKeyBytes(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private string GetRefreshToken(int id, string userName, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultIssuer, id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)
            };
            var now = _scopeService.RequestDateTimeUtc;
            var jwt = new JwtSecurityToken(
                ConstantsApp.AUTH_ISSUER,
                ConstantsApp.AUTH_AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(ConstantsApp.AUTH_REFRESH_TOKEN_LIFETIME)),
                signingCredentials: new SigningCredentials(ConstantsApp.GetAuthRefreshTokenSymmetricKeyBytes(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private int ValidateJwtBigExpireAndGetUser(string authToken)
        {
            var validationParameters = new TokenValidationParameters();
            validationParameters.ValidIssuer = ConstantsApp.AUTH_ISSUER;
            validationParameters.ValidAudience = ConstantsApp.AUTH_AUDIENCE;
            validationParameters.IssuerSigningKey = ConstantsApp.GetAuthJwtSymmetricKeyBytes();
            validationParameters.ValidateIssuerSigningKey = true;
            validationParameters.ValidateAudience = true;
            validationParameters.ValidateLifetime = true;
            validationParameters.LifetimeValidator = (notBefore, expires, token, @params) =>
            {
                if (expires.HasValue)
                {
                    return expires.Value.Add(TimeSpan.FromMinutes(-1 * ConstantsApp.AUTH_JWT_LIFETIME))
                               .Add(TimeSpan.FromMinutes(ConstantsApp.AUTH_REFRESH_TOKEN_LIFETIME)) >
                           _scopeService.RequestDateTimeUtc;
                }

                return false;
            };

            var validator = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            try
            {
                var principal = validator.ValidateToken(authToken, validationParameters, out validatedToken);
                var idStr = principal.Claims.First(x => x.Type == ClaimsIdentity.DefaultIssuer).Value;
                var id = int.Parse(idStr);
                return id;
            }
            catch (Exception e)
            {
                throw new BusinessLogicException(ExceptionCodes.AUTH_JWT_INCORRECT);
            }
        }

        private int ValidateCodeAndGetUser(string code)
        {
            var validationParameters = new TokenValidationParameters();
            validationParameters.ValidIssuer = ConstantsApp.AUTH_ISSUER;
            validationParameters.ValidAudience = ConstantsApp.AUTH_AUDIENCE;
            validationParameters.IssuerSigningKey = ConstantsApp.GetAuthCodeSymmetricKeyBytes();
            validationParameters.ValidateIssuerSigningKey = true;
            validationParameters.ValidateAudience = true;
            validationParameters.ValidateLifetime = true;
            var validator = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            try
            {
                var principal = validator.ValidateToken(code, validationParameters, out validatedToken);
                var idStr = principal.Claims.First(x => x.Type == ClaimsIdentity.DefaultIssuer).Value;
                var id = int.Parse(idStr);
                return id;
            }
            catch (Exception e)
            {
                throw new BusinessLogicException(ExceptionCodes.AUTH_CODE_INCORRECT);
            }
        }

        private int ValidateRefreshTokenAndGetUser(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters();
            validationParameters.ValidIssuer = ConstantsApp.AUTH_ISSUER;
            validationParameters.ValidAudience = ConstantsApp.AUTH_AUDIENCE;
            validationParameters.IssuerSigningKey = ConstantsApp.GetAuthRefreshTokenSymmetricKeyBytes();
            validationParameters.ValidateIssuerSigningKey = true;
            validationParameters.ValidateAudience = true;
            validationParameters.ValidateLifetime = true;
            var validator = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            try
            {
                var principal = validator.ValidateToken(refreshToken, validationParameters, out validatedToken);
                var idStr = principal.Claims.First(x => x.Type == ClaimsIdentity.DefaultIssuer).Value;
                var id = int.Parse(idStr);
                return id;
            }
            catch (Exception e)
            {
                throw new BusinessLogicException(ExceptionCodes.AUTH_REFRESH_TOKEN_INCORRECT);
            }
        }

        #endregion
    }
}
