using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ_InfraStructure;

    public static class QueueConsumer
    {

        public static void Consume(IModel channel)
        {
            channel.QueueDeclare("receive", true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("receive", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }

