using Cassandra;
using Cassandra.Mapping.Attributes;

namespace demo_cassandra.Domains.Entities;
public abstract class BaseUser :Timestamp
{

    public Guid UserId { get; set; }
    public string? FullName { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public bool? IsAdmin { get; set; }

}
public abstract class BaseUserDonViEntity  : BaseUser 
{
    public long? PhongBanID { get; set; }
    public string? TenPhongBan { get; set; }
    public long? ChucVuID { get; set; }
    public string? TenChucVu { get; set; }
}
public class UserEntity :  BaseUserDonViEntity 
{
    public long? UserSyncId { get; set; }
    public DateTime? LastOnline { get; set; }
}