using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vshope.Application.Auth.Abstr;
using Vshope.Common.Exception;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Auth;
using Vshope.Model.Model.Auth;

namespace Vshope.Application.Auth
{
    public class UserService:IUserService
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;

        public UserService(ContextApp context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var user = await _context.Users.WhereIsNotDeleted()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new BadRequestException(ExceptionCodes.COMMON_NOT_EXIST);
            }

            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }
    }
}
