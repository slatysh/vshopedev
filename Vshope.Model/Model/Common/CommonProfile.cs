using AutoMapper;
using Vshope.Model.DTO.Common;

namespace Vshope.Model.Model.Common
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<EntityApp, EntityAppDTO>()
                .IncludeAllDerived();

            CreateMap<EntityAppDTO, EntityApp>()
                .IncludeAllDerived();

            CreateMap<DictElement, DictElementDTO>()
                .IncludeAllDerived();

            CreateMap<DictElementDTO, DictElement>()
                .IncludeAllDerived();

            CreateMap<EntityScopedByCompany, EntityScopedByCompanyDTO>()
                .IncludeAllDerived();

            CreateMap<EntityScopedByCompanyDTO, EntityScopedByCompany>()
                .IncludeAllDerived()
                .ForMember(dest => dest.Company, opts => opts.Ignore());
        }
    }
}
