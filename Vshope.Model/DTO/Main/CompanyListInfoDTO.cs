using Vshope.Model.DTO.Common;

namespace Vshope.Model.DTO.Main
{
    public class CompanyListInfoDTO : EntityAppDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ManagerName { get; set; }
        public string ContactPhone { get; set; }
    }
}
