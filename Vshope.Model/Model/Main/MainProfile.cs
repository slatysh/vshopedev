using AutoMapper;
using Vshope.Model.DTO.Main;

namespace Vshope.Model.Model.Main
{
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductListInfoDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>()
                .ForMember(dest => dest.ProductAdType, opts => opts.Ignore())
                .ForMember(dest => dest.ProductApparel, opts => opts.Ignore())
                .ForMember(dest => dest.ProductCategory, opts => opts.Ignore())
                .ForMember(dest => dest.ProductGoodsType, opts => opts.Ignore())
                .ForMember(dest => dest.ProductType, opts => opts.Ignore());
            CreateMap<Company, CompanyListInfoDTO>();
        }
    }
}
