using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vshope.Application.Common.Abstr;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Dict;

namespace Vshope.Web.Controllers
{
    [ApiController]
    [Route("api/dict")]
    [Authorize]
    public class DictController : Controller
    {
        private readonly IDictService _dictService;

        public DictController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        ///     WEB COMMON get product type dict
        /// </summary>
        [Route("productType")]
        [HttpGet]
        public async Task<ListResultDTO<ProductTypeDTO>> ProductTypeGetDict()
        {
            var result = await _dictService.GetProductTypeDict();
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product category dict
        /// </summary>
        [Route("productCategory/{productTypeId}")]
        [HttpGet]
        public async Task<ListResultDTO<ProductCategoryDTO>> ProductCategoryGetDict(int productTypeId)
        {
            var result = await _dictService.GetProductCategoryDict(productTypeId);
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product goods type dict
        /// </summary>
        [Route("productGoodsType/{productCategoryId}")]
        [HttpGet]
        public async Task<ListResultDTO<ProductGoodsTypeDTO>> ProductGoodsTypeGetDict(int productCategoryId)
        {
            var result = await _dictService.GetProductGoodsTypeDict(productCategoryId);
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product apparel dict
        /// </summary>
        [Route("productApparel/{productGoodsTypeId}")]
        [HttpGet]
        public async Task<ListResultDTO<ProductApparelDTO>> ProductApparelGetDict(int productGoodsTypeId)
        {
            var result = await _dictService.GetProductApparelDict(productGoodsTypeId);
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product size dict
        /// </summary>
        [Route("productSize/{productGoodsTypeId}/{productApparelId}")]
        [HttpGet]
        public async Task<ListResultDTO<ProductSizeDTO>> ProductSizeGetDict(int productGoodsTypeId, int? productApparelId)
        {
            var result = await _dictService.GetProductSizeDict(productGoodsTypeId, productApparelId);
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product adType dict
        /// </summary>
        [Route("adType")]
        [HttpGet]
        public async Task<ListResultDTO<ProductAdTypeDTO>> ProductAdTypeGetDict()
        {
            var result = await _dictService.GetProductAdTypeDict();
            return result;
        }

        /// <summary>
        ///     WEB COMMON get product condition dict
        /// </summary>
        [Route("condition")]
        [HttpGet]
        public async Task<ListResultDTO<ProductConditionDTO>> ProductConditionGetDict()
        {
            var result = await _dictService.GetProductConditionDict();
            return result;
        }
    }
}
