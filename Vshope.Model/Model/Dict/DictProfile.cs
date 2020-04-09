using AutoMapper;
using Vshope.Model.DTO.Dict;
using Vshope.Model.DTO.Main;
using Vshope.Model.Model.Main;

namespace Vshope.Model.Model.Dict
{
    public class DictProfile : Profile
    {
        public DictProfile()
        {
            CreateMap<UserStatus, UserStatusDTO>();

            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<ProductAdType, ProductAdTypeDTO>();
            CreateMap<ProductApparel, ProductApparelDTO>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductGoodsType, ProductGoodsTypeDTO>();
            CreateMap<ProductSize, ProductSizeDTO>();
        }
    }
}
