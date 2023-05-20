using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace RabbitMQ_InfraStructure;

    public static class QueueProducer
    {
        public static void Publish(IModel channel,Form message )
        {
            channel.QueueDeclare("send",true,false,false,null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish("", "sendKey", null, body);


        }
    }

