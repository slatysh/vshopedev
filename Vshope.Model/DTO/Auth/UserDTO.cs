using Vshope.Model.DTO.Main;

namespace Vshope.Model.DTO.Auth
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public int? CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        public int? StatusId { get; set; }
        public string StatusStr { get; set; }
    }
}
