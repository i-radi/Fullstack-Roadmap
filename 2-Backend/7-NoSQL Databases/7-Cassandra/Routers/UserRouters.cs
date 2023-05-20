using demo_cassandra.Domains.Entities;
using demo_cassandra.Domains.Services;

namespace message_service.Routers;

public static class UserRouters
{
    public static void UserMap(this IEndpointRouteBuilder app)
    {
        string groupName = "/users";

        app.MapGet($"{groupName}/user-info", async (IUserService userService, string Id) =>
        {
            return await userService.GetUserInfo(id: Id);
        }).WithTags(groupName);

        app.MapGet($"{groupName}/online-user", async (IUserService userService, string userId) =>
        {
            return await userService.GetOnlineUser(userId);
        }).WithTags(groupName);

        app.MapPost($"{groupName}/add-user", async (IUserService userService, UserEntity user) =>
        {
            return await userService.SyncUser(user);
        }).WithTags(groupName);
        app.MapPost($"{groupName}/add-online-user", async (IUserService userService, string userId) =>
        {
            return await userService.AddUserOnline(userId);
        }).WithTags(groupName);
        app.MapPost($"{groupName}/update-online-user", async (IUserService userService, string userId,string onlineUserId) =>
        {
            return await userService.UpdateOnlineUser(userId, onlineUserId);
        }).WithTags(groupName);
        app.MapPost($"{groupName}/remove-online-user", async (IUserService userService, string userId,string onlineUserId) =>
        {
            return await userService.RemoveOnlineUser(userId, onlineUserId);
        }).WithTags(groupName);
    }

}
