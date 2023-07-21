using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace RabbitMQ_InfraStructure;

public static class QueueProducer
{
	public static void Publish(IModel channel, Form message)
	{
		channel.QueueDeclare("test", true, false, false, null);
		var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
		channel.BasicPublish("", "test", null, body);


	}
}

