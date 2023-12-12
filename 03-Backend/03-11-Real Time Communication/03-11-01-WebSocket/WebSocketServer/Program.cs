using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using WebSocketServer.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebSocketServerConnectionManager();

var app = builder.Build();

app.UseWebSockets();

app.UseWebSocketServer();

app.Run(async context =>
{
    Console.WriteLine("Hello from 3rd (terminal) Request Delegate");
    await context.Response.WriteAsync("Hello from 3rd (terminal) Request Delegate");
});







