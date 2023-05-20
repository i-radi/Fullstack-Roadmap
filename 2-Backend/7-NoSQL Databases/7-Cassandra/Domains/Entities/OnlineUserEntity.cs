using Cassandra;
using Cassandra.Mapping;
using Cassandra.Mapping.Attributes;

namespace demo_cassandra.Domains.Entities;

public class OnlineUserEntity : BaseUser
{
    public TimeUuid OnlineUserId { get; set; }
    public List<int>? NumArr { get; set; }
    public Temp? Temp { get; set; }
    public string? DummyData { get; set; }

}
public class Temp
{
    public string? Name { get; set; }
    public Guid TempId { get; set; }
    [Frozen]
    public Temp2? Temp2 { get; set; }
}
public class Temp2
{
    public string? Name { get; set; }
    public Guid TempId { get; set; }
}