namespace EPIRoboticFuelLogger.Models;

public class Log : ILog
{
    public string Message { get; set; } = string.Empty;
    public string AuthorizationID { get; set; } = string.Empty;
    public int ResponseCode { get; set; }
    public string ResponseMessage { get; set; } = string.Empty;
    public DateTime ResponseTime { get; set; }
    public DateTime FuelingStartTime { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public int UserAccountID { get; set; }
}
