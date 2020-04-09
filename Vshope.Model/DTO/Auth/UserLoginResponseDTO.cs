namespace Vshope.Model.DTO.Auth
{
    public class UserLoginResponseDTO
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int? CompanyId { get; set; }
        public string RefreshToken { get; set; }
    }
}
