using AutoMapper;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.WebApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateDTO, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => new Email(x.EmailAddress)))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(x => new CustomerName(x.FirstName, x.LastName)));

            CreateMap<CustomerUpdateDTO, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => new Email(x.EmailAddress)))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(x => new CustomerName(x.FirstName, x.LastName)))
                 .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerCreateDTO>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.Name.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.Name.LastName))
               .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.Email.Address));

            CreateMap<Customer, CustomerUpdateDTO>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.Name.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.Name.LastName))
               .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.Email.Address));

        }
    }
}
