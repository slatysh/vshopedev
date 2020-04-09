using System.Threading.Tasks;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;

namespace Vshope.Application.Main.Abstr
{
    public interface IProductService
    {
        Task<ListResultDTO<ProductListInfoDTO>> GetProductList(ListRequestDTO listRequestDTO,
            int companyId);

        Task GetAndSaveProductListFromVk(int companyId, string vkToken);

        Task<int> GetProductCountFromVk(int companyId, string vkToken);
    }
}
