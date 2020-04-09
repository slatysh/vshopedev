using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vshope.Application.Main.Abstr;
using Vshope.Common;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;
using Vshope.Web.Helpers;
using Vshope.Web.Validation;

namespace Vshope.Web.Controllers
{
    [ApiController]
    [Route("api/company")]
    [AllowAnonymous]
    public class CompanyController : Controller
    {
        readonly ICompanyService _companyService;
        readonly CompanyDTOValidator _companyDTOValidator;

        public CompanyController(ICompanyService companyService, CompanyDTOValidator companyDTOValidator)
        {
            _companyService = companyService;
            _companyDTOValidator = companyDTOValidator;
        }

        /// <summary>
        ///     WEB ADMIN create company
        /// </summary>
        [Route("create")]
        [HttpPost]
        [Authorize(Roles = UserRoleNames.ADMIN)]
        public async Task<CompanyDTO> CompanyCreate([FromBody] CompanyDTO companyDTO, [FromQuery] string vkToken)
        {
            _companyDTOValidator.ValidateAndThrow(companyDTO);
            var result = await _companyService.CreateCompany(companyDTO, vkToken);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN delete company by id
        /// </summary>
        [Route("delete/{companyId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN)]
        public async Task<CompanyDTO> CompanyDelete([FromRoute] int companyId)
        {
            var result = await _companyService.DeleteCompany(companyId);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER get company by id
        /// </summary>
        [Route("get/{companyId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<CompanyDTO> CompanyGet([FromRoute] int companyId)
        {
            this.CheckAndGetCurrentUserCompanyId(companyId);
            var result = await _companyService.GetCompany(companyId);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN get shop list (paged)
        /// </summary>
        [Route("get/list")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN)]
        public async Task<ListResultDTO<CompanyListInfoDTO>> CompanyGetList([FromQuery] ListRequestDTO listRequest)
        {
            var result = await _companyService.GetCompanyList(listRequest);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN update company
        /// </summary>
        [Route("update")]
        [HttpPut]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<CompanyDTO> CompanyUpdate([FromBody] CompanyDTO companyDTO, [FromQuery] string vkToken)
        {
            this.CheckAndGetCurrentUserCompanyId(companyDTO.Id);
            _companyDTOValidator.ValidateAndThrow(companyDTO);
            var result = await _companyService.UpdateCompany(companyDTO, vkToken);
            return result;
        }
    }
}
