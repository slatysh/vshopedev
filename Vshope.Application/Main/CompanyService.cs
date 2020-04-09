using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vshope.Application.Auth.Abstr;
using Vshope.Application.Extension;
using Vshope.Application.Main.Abstr;
using Vshope.Common;
using Vshope.Common.Exception;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Auth;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;
using Vshope.Model.Model.Main;

namespace Vshope.Application.Main
{
    public class CompanyService:ICompanyService
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IVkService _vkService;


        public CompanyService(ContextApp context, IMapper mapper, IAuthService authService, IVkService vkService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
            _vkService = vkService;
        }

        public async Task<CompanyDTO> CreateCompany(CompanyDTO companyDTO, string vkToken)
        {
            var newCompany = _mapper.Map<CompanyDTO, Company>(companyDTO);
            var savedCompany = (await _context.Companies.AddAsync(newCompany)).Entity;
            var newUser = await _authService.RegisterNoSave(new UserRegisterDTO
            {
                Email = companyDTO.Email,
                Password = companyDTO.Password,
                Company = savedCompany,
                UserName = companyDTO.Email
            });
            var vkId = await _vkService.GetCompanyIdFromVk(companyDTO.VkStr, vkToken);
            newCompany.VkId = vkId;
            await _context.SaveChangesAsync();
            await _authService.RegisterSendEmail(newUser);
            var savedCompanyDTO = _mapper.Map<Company, CompanyDTO>(savedCompany);
            return savedCompanyDTO;
        }

        public async Task<CompanyDTO> DeleteCompany(int id)
        {
            var companyFromDb = await _context.Companies.WhereIsNotDeleted(x => x.Id == id).FirstOrDefaultAsync();
            if (companyFromDb == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }

            var userFromDb = await _context.Users.WhereIsNotDeleted(x => x.CompanyId == id).SingleOrDefaultAsync();
            if (userFromDb == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }

            var productsFromDb = await _context.Products.WhereIsNotDeleted(x => x.CompanyId == id).ToListAsync();
            foreach (var product in productsFromDb)
            {
                product.IsDeleted = true;
            }

            var removedCompanyDTO = _mapper.Map<Company, CompanyDTO>(companyFromDb);
            companyFromDb.IsDeleted = true;
            userFromDb.IsDeleted = true;
            await _context.SaveChangesAsync();
            return removedCompanyDTO;
        }

        public async Task<CompanyDTO> GetCompany(int id)
        {
            var company = await _context.Companies
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (company == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }

            var companyDTO = _mapper.Map<Company, CompanyDTO>(company);
            return companyDTO;
        }

        public async Task<ListResultDTO<CompanyListInfoDTO>> GetCompanyList(ListRequestDTO listRequestDTO)
        {
            var query = _context.Companies.WhereIsNotDeleted();
            var total = await query.CountAsync();
            var items = await query.ApplyListRequestFilter(listRequestDTO, OrderKeySelectorFromString)
                .ProjectTo<CompanyListInfoDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            var result =
                new ListResultDTO<CompanyListInfoDTO>(items, total);
            return result;
        }

        public async Task<CompanyDTO> UpdateCompany(CompanyDTO companyDTO, string vkToken)
        {
            var company = _mapper.Map<CompanyDTO, Company>(companyDTO);
            var companyFromDb = await _context.Companies.WhereIsNotDeleted(x => x.Id == companyDTO.Id).FirstOrDefaultAsync();
            if (companyFromDb == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }

            if (companyFromDb.Email != companyDTO.Email)
            {
                throw new BusinessLogicException(ExceptionCodes.READONLY_FIELD);
            }

            _context.SetValuesApp(companyFromDb, company);
            var vkId = await _vkService.GetCompanyIdFromVk(companyDTO.VkStr, vkToken);
            companyFromDb.VkId = vkId;

            var userFromDb = await _context.Users.WhereIsNotDeleted(x => x.CompanyId == companyFromDb.Id).FirstAsync();
            if (!PasswordHelper.VerifyPassword(companyDTO.Password, userFromDb.PasswordHash))
            {
                var newPasswordHash = PasswordHelper.GetPasswordHash(companyDTO.Password);
                userFromDb.PasswordHash = newPasswordHash;
            }
            await _context.SaveChangesAsync();

            var updatedCompanyDTO = _mapper.Map<Company, CompanyDTO>(companyFromDb);
            return updatedCompanyDTO;
        }

        private Expression<Func<Company, object>> OrderKeySelectorFromString(string key)
        {
            switch (key)
            {
                case "itemName":
                    return x => x.Name;
                case "itemEmail":
                    return x => x.Email;
                case "itemManagerName":
                    return x => x.ManagerName;
                case "itemContactPhone":
                    return x => x.ContactPhone;
                default: throw new BusinessLogicException(ExceptionCodes.BL_CODE_ORDER_BY_KEY_NOT_DEFINED);
            }
        }
    }
}
