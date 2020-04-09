using System.Collections.Generic;
using System.Threading.Tasks;
using Vshope.Model.DTO.Main;

namespace Vshope.Application.Main.Abstr
{
    public interface IVkService
    {
        Task<string> GetAccessToken(string code, string redirectUri);

        Task<int> GetAndSaveProductList(int companyId, string vkToken);

        Task<int> GetProductCountFromVk(int companyId, string vkToken);

        Task<long?> GetCompanyIdFromVk(string vkStr, string vkToken);
    }
}
