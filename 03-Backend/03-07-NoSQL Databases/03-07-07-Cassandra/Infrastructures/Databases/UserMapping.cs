using Cassandra;
using Cassandra.Mapping;
using demo_cassandra.Domains.Entities;

namespace demo_cassandra.Infrastructures.Databases;

public class UserMapping : Mappings
{
    public UserMapping()
    {
        // Define mappings in the constructor of your class
        // that inherits from Mappings
        For<UserEntity>()
           .TableName("users")
           .PartitionKey(x => x.UserId);

        For<OnlineUserEntity>()
           .TableName("online_users")
           .PartitionKey(x => x.UserId)
           .ClusteringKey(x => x.OnlineUserId, SortOrder.Descending)
           .Column(u => u.Temp, cm => cm.WithName("temp").AsFrozen());

    }
}

