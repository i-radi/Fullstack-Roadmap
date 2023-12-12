using Microsoft.AspNetCore.SignalR;
using SignalRServer.Handlers;
using System;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    //https://stackoverflow.com/questions/13514259/get-number-of-listeners-clients-connected-to-signalr-hub
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"];

            if (!string.IsNullOrEmpty(userId))
            {
                HubConnectionManager.AddConnection(userId, Context.ConnectionId);
            }

            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID", Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            HubConnectionManager.RemoveConnection(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUser(string userId, string message)
        {
            var connectionId = HubConnectionManager.GetConnectionId(userId);
            if (connectionId != null)
            {
                await Clients.Client(connectionId).SendAsync("GetMessageToUser", userId, message);
            }
            //save message in db
        }

        public async Task SendMessageToGroup(string groupName, string message)
        {
            //groupTable(id,name)
            //usersgroup(gid,userid)

            //onConnect: if userid in usersgroup => Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.OthersInGroup(groupName).SendAsync("GetMessageToGroup", message);
            //save message in db
        }

        public async Task AddUserToGroup(string userId, string groupName)
        {
            var connectionId = HubConnectionManager.GetConnectionId(userId);
            if (connectionId != null)
            {
            await Groups.AddToGroupAsync(connectionId, groupName);
            }

            //save message in db
            //groupTable(id,name)
            //usersgroup(gid,userid)
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.Others.SendAsync("GetMessageToAll", message);
            //save message in db
        }
    }
}