
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace FCM_Demo.Services.Notifications;

public class FirebaseNotificationService : INotificationService
{
    public FirebaseNotificationService()
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("FCM_Private_Key.json"),
        });
    }

    public Task<string> GetFCMTokenAsync(string userId)
    {
        // get token from user table
        throw new NotImplementedException();
    }
    public Task<bool> UpdateFCMTokenAsync(string token, string userId)
    {
        // update token into user table
        throw new NotImplementedException();
    }

    public async Task<string> SendNotificationAsync(string token, string title, string body)
    {
        var message = new Message()
        {
            Token = token,
            Notification = new Notification()
            {
                Title = title,
                Body = body
            }
        };

        return await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
    public async Task<string> SendTopicNotificationAsync(string topic, string title, string body)
    {
        var message = new Message()
        {
            Topic = topic,
            Notification = new Notification()
            {
                Title = title,
                Body = body
            }
        };

        return await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}
