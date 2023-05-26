using RabbitMQ.Client;

namespace RabbitMQ_InfraStructure;

public class Factory
{
    public IModel Create()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        return channel;     

    }
}