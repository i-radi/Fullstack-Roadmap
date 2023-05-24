using demo_cassandra.Domains.DTOs;
using demo_cassandra.Domains.Entities;

namespace demo_cassandra.Domains.Services;

public interface IUserService
{
    Task<UserEntity?> GetUserInfo(string id);
    Task<bool> SyncUser(UserEntity data);
    Task<bool> AddUserOnline(string userId);
    Task<List<OnlineUserEntity?>?> GetOnlineUser(string userId);
    Task<bool> UpdateOnlineUser(string userId, string onlineUserId);
    Task<bool> RemoveOnlineUser(string userId, string onlineUserId);

}
