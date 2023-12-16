namespace FCM_Demo.Services.Notifications;

public interface INotificationService
{
    Task<string> GetFCMTokenAsync(string token);
    Task<bool> UpdateFCMTokenAsync(string token, string userId);
    Task<string> SendNotificationAsync(string token, string title, string body);
    Task<string> SendTopicNotificationAsync(string topic, string title, string body);
}
