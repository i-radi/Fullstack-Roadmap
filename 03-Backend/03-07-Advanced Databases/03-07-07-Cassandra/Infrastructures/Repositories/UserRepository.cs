
using Cassandra;
using Cassandra.Data.Linq;
using demo_cassandra.Domains.Entities;
using demo_cassandra.Domains.Services;

namespace message_service.Infrastructures.Repository;

public class UserRepository : IUserService
{

    private readonly Cassandra.ISession _session;
    private readonly AutoMapper.IMapper _mapper;
    private readonly Table<UserEntity> users;
    private readonly Table<OnlineUserEntity> onlineUsers;
    public UserRepository(Cassandra.ISession session, AutoMapper.IMapper mapper)
    {
        _mapper = mapper;
        _session = session;

        users = new Table<UserEntity>(session);
        onlineUsers = new Table<OnlineUserEntity>(session);
    }

    public async Task<UserEntity?> GetUserInfo(string id)
    {
        try
        {
            UserEntity? a = await users.FirstOrDefault(u => u.UserId == Guid.Parse(id)).ExecuteAsync();


            //string s = a.Id.ToString();
            //bool b = s == id;

            return a;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> SyncUser(UserEntity data)
    {
        try
        {
            await users.CreateIfNotExistsAsync();

            data.UserId = Guid.NewGuid();
            await users.Insert(data).ExecuteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public async Task<bool> AddUserOnline(string userId)
    {
        try
        {

            await onlineUsers.CreateIfNotExistsAsync();

            var user = await users.FirstOrDefault(u => u.UserId == Guid.Parse(userId)).ExecuteAsync();
            OnlineUserEntity onlineUserEntity = _mapper.Map<UserEntity, OnlineUserEntity>(user);
            onlineUserEntity.OnlineUserId = TimeUuid.NewId();
            onlineUserEntity.CreateAt = DateTime.Now;
            onlineUserEntity.UpdateAt = DateTime.Now;
            onlineUserEntity.NumArr = new() { 1, 2, 3 };
            //onlineUserEntity.Temp = new() { Name = "Hello Nam nè", TempId = Guid.NewGuid(), Temp2 = new() { Name = "Hello Nam nè", TempId = Guid.NewGuid() } };
            onlineUserEntity.DummyData = "Nam nè";

            await onlineUsers.Insert(onlineUserEntity).ExecuteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<List<OnlineUserEntity?>?> GetOnlineUser(string userId)
    {
        try
        {
            //var rs = onlineUsers.SetAutoPage(autoPage: false).SetPageSize(2).ExecutingAs(userId);
            //var pagingState = rs.PagingState;

            //IEnumerable<OnlineUserEntity?>? data = await onlineUsers.Where(x=>x.IsAdmin ==false).AllowFiltering().ExecuteAsync();


            IEnumerable<OnlineUserEntity?>? data = await onlineUsers.ExecuteAsync();

            //var rs2 = onlineUsers.SetPagingState(pagingState).ExecutingAs(userId);
            return data?.ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> UpdateOnlineUser(string userId, string onlineUserId)
    {
        try
        {
            var user = await onlineUsers.Where(x => x.UserId == Guid.Parse(userId) && x.OnlineUserId == TimeUuid.Parse(onlineUserId)).FirstOrDefault().ExecuteAsync();
            user?.NumArr?.Add(DateTime.Now.Second);

            var guid = Guid.Parse("386d0ca9-9f11-4c0e-bd11-c9b8dbb0e56c");

            user.Temp.Temp2.Name = "Lại là Nam nè hihi";

            var a = onlineUsers
                .Where(x => x.UserId == Guid.Parse(userId) && x.OnlineUserId == TimeUuid.Parse(onlineUserId))
                .Select(x => new OnlineUserEntity() { Temp = user.Temp, NumArr = x.NumArr.Append(10).ToList() })
                .Update();

            await a.ExecuteAsync();

            //var profileStmt = _session.Prepare("UPDATE online_users SET hello=? WHERE userid=? AND onlineuserid =?");
            //var statement = profileStmt.Bind(new List<int>() { 4, 5, 6 }, Guid.Parse(userId), TimeUuid.Parse(onlineUserId));
            //await _session.ExecuteAsync(statement);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    } 
    public async Task<bool> RemoveOnlineUser(string userId, string onlineUserId)
    {
        try
        {
          

            var a = onlineUsers
                //.Where(x => x.UserId == Guid.Parse(userId) && x.OnlineUserId == TimeUuid.Parse(onlineUserId))
                .Where(x => x.OnlineUserId == TimeUuid.Parse(onlineUserId))
                .Delete();

            await a.ExecuteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
