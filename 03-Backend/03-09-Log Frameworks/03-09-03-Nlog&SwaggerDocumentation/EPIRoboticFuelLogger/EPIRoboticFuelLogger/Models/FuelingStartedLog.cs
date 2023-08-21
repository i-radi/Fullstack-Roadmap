namespace EPIRoboticFuelLogger.Models;

public class FuelingStartedLog : ILog
{
    public string Message { get; set; } = string.Empty;
    public string AuthorizationID { get; set; } = string.Empty;
    public DateTime FuelingStartTime { get; set; }
}
