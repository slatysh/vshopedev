using Vshope.Model.Model.Main;

namespace Vshope.Model.DTO.Auth
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
    }
}
