﻿using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace RabbitMQ_InfraStructure;

public static class DirectExchangePublisher
{
    public static void Publish(IModel channel)
    {
        var ttl = new Dictionary<string, object>
        {
            {"x-message-ttl", 30000 }
        };
        channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct, arguments: ttl);
        var count = 0;

        while (true)
        {
            var message = new { Name = "Producer", Message = $"Hello! Count: {count}" };
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
            count++;
            Thread.Sleep(1000);
        }
    }
}