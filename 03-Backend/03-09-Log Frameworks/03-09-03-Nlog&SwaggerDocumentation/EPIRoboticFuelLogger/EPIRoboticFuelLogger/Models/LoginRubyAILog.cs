namespace EPIRoboticFuelLogger.Models;

public class LoginRubyAILog : ILog
{
    public string Message { get; set; } = string.Empty;
    public int ResponseCode { get; set; }
    public string ResponseMessage { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public int UserAccountID { get; set; }
}
