using AutoMapper;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.WebApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Price.Amount));
            
            CreateMap<ProductCreateDTO, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => new ProductName(x.Name)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(x => new Price(x.Price)));
        }
    }
}
