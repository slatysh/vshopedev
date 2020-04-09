using System.Threading.Tasks;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Dict;

namespace Vshope.Application.Common.Abstr
{
    public interface IDictService
    {
        Task<ListResultDTO<ProductTypeDTO>> GetProductTypeDict();
        Task<ListResultDTO<ProductCategoryDTO>> GetProductCategoryDict(int productTypeId);
        Task<ListResultDTO<ProductGoodsTypeDTO>> GetProductGoodsTypeDict(int productCategoryId);
        Task<ListResultDTO<ProductApparelDTO>> GetProductApparelDict(int productGoodsTypeId);
        Task<ListResultDTO<ProductSizeDTO>> GetProductSizeDict(int productGoodsTypeId, int? productApparelId);
        Task<ListResultDTO<ProductAdTypeDTO>> GetProductAdTypeDict();
        Task<ListResultDTO<ProductConditionDTO>> GetProductConditionDict();
    }
}
