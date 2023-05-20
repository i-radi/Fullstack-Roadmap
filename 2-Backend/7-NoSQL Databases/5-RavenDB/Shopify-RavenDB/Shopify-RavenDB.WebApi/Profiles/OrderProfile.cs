using AutoMapper;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.WebApi.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderLine, OrderLineCreateDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(x => x.Quantity));

            CreateMap<Order, OrderCreateDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(x => x.Discount));

            CreateMap<OrderCreateDTO, Order>()
                .ConstructUsing(x => new Order(x.CustomerId, x.Discount));

            CreateMap<OrderLineCreateDTO, OrderLine>()
                .ConstructUsing(x => new OrderLine(x.ProductId, x.Quantity));
        }
    }
}
