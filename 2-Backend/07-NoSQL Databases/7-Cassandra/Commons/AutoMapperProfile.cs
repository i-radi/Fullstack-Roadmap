
using AutoMapper;
using demo_cassandra.Domains.Entities;

namespace demo_cassandra.Commons;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserEntity, OnlineUserEntity>();
    }
}


