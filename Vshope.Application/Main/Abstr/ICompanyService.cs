using System.Threading.Tasks;
using Vshope.Model.DTO.Common;
using Vshope.Model.DTO.Main;

namespace Vshope.Application.Main.Abstr
{
    public interface ICompanyService
    {
        Task<CompanyDTO> CreateCompany(CompanyDTO companyDTO, string vkToken);

        Task<CompanyDTO> DeleteCompany(int id);

        Task<CompanyDTO> GetCompany(int id);

        Task<ListResultDTO<CompanyListInfoDTO>> GetCompanyList(ListRequestDTO listRequestDTO);

        Task<CompanyDTO> UpdateCompany(CompanyDTO companyDTO, string vkToken);
    }
}
