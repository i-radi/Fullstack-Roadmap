using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebSocketServer.Manager;

namespace WebSocketServer.Middleware;

public static class WebSocketServerMiddlewareExtensions
{
    public static IServiceCollection AddWebSocketServerConnectionManager(this IServiceCollection services)
    {
        //services.AddTransient<WebSocketServerConnectionManager>();
        services.AddSingleton<WebSocketServerConnectionManager>();
        return services;
    }

    public static IApplicationBuilder UseWebSocketServer(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WebSocketServerMiddleware>();
    }
}