namespace RabbitMQ_AP_Dotnet6;
    public interface IRabbitMqProducer
    {
        public void SendProductMessage<T>(T message);
    }

