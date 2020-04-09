using System.Threading.Tasks;
using AspNet.Security.OAuth.Vkontakte;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Vshope.Application.Auth.Abstr;
using Vshope.Application.Main.Abstr;
using Vshope.Common;
using Vshope.Model.DTO.Auth;
using Vshope.Web.Helpers;
using Vshope.Web.Validation;

namespace Vshope.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserLoginDTOValidator _userLoginDTOValidator;
        private readonly IUserService _userService;
        private readonly IVkService _vkService;

        public UserController(IAuthService authService, IUserService userService,
            UserLoginDTOValidator userLoginDTOValidator, IVkService vkService)
        {
            _authService = authService;
            _userService = userService;
            _vkService = vkService;
            _userLoginDTOValidator = userLoginDTOValidator;
        }

        /// <summary>
        ///     WEB ANONIMOUS confirm email
        /// </summary>
        [Route("confirmEmail")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<UserDTO> UserConfirmEmail([FromQuery] string code)
        {
            var result = await _authService.ConfirmEmail(code);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER get user by id
        /// </summary>
        [Route("get/{userId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<UserDTO> UserGet([FromRoute] int userId)
        {
            this.CheckAndGetCurrentUserId(userId);
            var result = await _userService.GetUser(userId);
            return result;
        }

        /// <summary>
        ///     WEB ANONIMOUS login user
        /// </summary>
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserLoginResponseDTO> UserLogin([FromBody] UserLoginDTO userLoginDto)
        {
            _userLoginDTOValidator.ValidateAndThrow(userLoginDto);
            var result = await _authService.Login(userLoginDto);
            return result;
        }

        /// <summary>
        ///     WEB ANONIMOUS Vk login user
        /// </summary>
        [Route("loginVkAccessToken")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<string> UserLoginVkAccessToken([FromQuery] string code, [FromQuery] string redirectUri)
        {

            var token = await _vkService.GetAccessToken(code, redirectUri);
            return token;
        }

        /// <summary>
        ///     WEB ANONIMOUS refresh token
        /// </summary>
        [Route("refreshToken")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<UserLoginResponseDTO> UserRefreshToken([FromQuery] string jwtToken,
            [FromQuery] string refreshToken)
        {
            var result = await _authService.RefreshToken(jwtToken, refreshToken);
            return result;
        }
    }
}
