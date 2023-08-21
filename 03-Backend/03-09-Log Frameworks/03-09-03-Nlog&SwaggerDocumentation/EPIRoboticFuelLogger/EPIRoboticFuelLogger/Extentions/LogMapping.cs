using EPIRoboticFuelLogger.Models;

namespace EPIRoboticFuelLogger.Extentions;

public static class LogMapping
{
    public static ILog Mapping(this Log log)
    {
        if (log == null)
            throw new ArgumentNullException(nameof(log));

        if (log.Message == "StartFueling")
            return new StartFuelingLog
            {
                Message = log.Message,
                AuthorizationID = log.AuthorizationID,
                ResponseCode = log.ResponseCode,
                ResponseMessage = log.ResponseMessage,
                ResponseTime = log.ResponseTime
            };

        if (log.Message == "FuelingStarted")
            return new FuelingStartedLog
            {
                Message = log.Message,
                AuthorizationID = log.AuthorizationID,
                FuelingStartTime = log.FuelingStartTime
            };

        if (log.Message == "StopFueling")
            return new StopFuelingLog
            {
                Message = log.Message,
                AuthorizationID = log.AuthorizationID,
                ResponseCode = log.ResponseCode,
                ResponseMessage = log.ResponseMessage,
                ResponseTime = log.ResponseTime,
            };

        if (log.Message == "LoginRubyAI")
            return new LoginRubyAILog
            {
                Message = log.Message,
                ResponseCode = log.ResponseCode,
                ResponseMessage = log.ResponseMessage,
                AccessToken = log.AccessToken,
                UserAccountID = log.UserAccountID
            };

        throw new InvalidOperationException("Invalid Message");

    }
}
