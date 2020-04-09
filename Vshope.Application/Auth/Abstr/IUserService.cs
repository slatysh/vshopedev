using System.Threading.Tasks;
using Vshope.Model.DTO.Auth;

namespace Vshope.Application.Auth.Abstr
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(int id);
    }
}
