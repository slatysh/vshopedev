using AutoMapper;
using Vshope.Model.DTO.Auth;
using Vshope.Model.Model.Dict;

namespace Vshope.Model.Model.Auth
{
    public class AuthProfile: Profile
    {
        public AuthProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.StatusStr, opts => opts.MapFrom(src => UserStatusEnumHelper.ToString((UserStatusEnum)src.StatusId)));
        }
    }
}
