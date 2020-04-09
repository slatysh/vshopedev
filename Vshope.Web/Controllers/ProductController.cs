using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vshope.Application.Main.Abstr;
using Vshope.Common;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;
using Vshope.Web.Helpers;

namespace Vshope.Web.Controllers
{

    [ApiController]
    [Route("api/product")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER get and save product list 
        /// </summary>
        [Route("/getAndSaveListFromVk/{companyId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task ProductGetAndSaveListFromVk([FromRoute] int companyId, [FromQuery] string vkToken)
        {
            this.CheckAndGetCurrentUserCompanyId(companyId);
            await _productService.GetAndSaveProductListFromVk(companyId, vkToken);
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER get product count
        /// </summary>
        [Route("/getCountFromVk/{companyId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<int> ProductGetCountFromVk([FromRoute] int companyId, [FromQuery] string vkToken)
        {
            this.CheckAndGetCurrentUserCompanyId(companyId);
            var result = await _productService.GetProductCountFromVk(companyId, vkToken);
            return result;
        }

        /// <summary>
        ///     WEB ADMIN_AND_USER get products
        /// </summary>
        [Route("/list/{companyId}")]
        [HttpGet]
        [Authorize(Roles = UserRoleNames.ADMIN_AND_USER)]
        public async Task<ListResultDTO<ProductListInfoDTO>> ProductGetList([FromQuery] ListRequestDTO listRequest, [FromRoute] int companyId)
        {
            this.CheckAndGetCurrentUserCompanyId(companyId);
            var result = await _productService.GetProductList(listRequest, companyId);
            return result;
        }
    }
}
