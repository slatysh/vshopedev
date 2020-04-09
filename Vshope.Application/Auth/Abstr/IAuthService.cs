using System.Threading.Tasks;
using Vshope.Model.DTO.Auth;
using Vshope.Model.Model.Auth;

namespace Vshope.Application.Auth.Abstr
{
    public interface IAuthService
    {
        Task<UserDTO> ConfirmEmail(string code);

        Task<UserLoginResponseDTO> Login(UserLoginDTO dto);

        Task<UserLoginResponseDTO> RefreshToken(string jwtToken, string refreshToken);

        Task<User> RegisterNoSave(UserRegisterDTO dto);

        Task RegisterSendEmail(User newUser);

        Task<UserDTO> ResetPassword(string code, string newPassword);
    }
}
