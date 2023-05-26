using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace demo_cassandra.Domains.DTOs;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class UserDTO
{
    public Guid Id { get; set; }
    public long? UserId { get; set; }
    public string? Email { get; set; } 
    public string? FullName { get; set; } 
    public string? Avatar { get; set; }
    public long? PhongBanID { get; set; }
    public string? TenPhongBan { get; set; }
    public long? ChucVuID { get; set; } 
    public string? TenChucVu { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; } = "male";
    public bool? IsAdmin { get; set; }
    public DateTime? LastOnline { get; set; }
}
