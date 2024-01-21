
namespace demo_cassandra.Domains.Entities;

public abstract class Timestamp
{
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}
