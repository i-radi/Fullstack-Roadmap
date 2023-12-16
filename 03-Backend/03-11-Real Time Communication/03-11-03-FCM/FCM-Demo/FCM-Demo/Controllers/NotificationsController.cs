using FCM_Demo.Services.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace FCM_Demo.Controllers;
[ApiController]
[Route("[controller]")]
public class NotificationsController(INotificationService notificationService) : ControllerBase
{
    private readonly INotificationService _notificationService = notificationService;

    [HttpGet()]
    public async Task<IActionResult> SendTopicNotification(string title, string body)
    {
        var result = await _notificationService.SendTopicNotificationAsync("all", title, body);
        return Ok(new { result });
    }
}
