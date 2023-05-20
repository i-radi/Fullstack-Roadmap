
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ_InfraStructure;

namespace RabbitMQ_AP_Dotnet6
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IRabbitMqProducer _rabbitMqProducer;
        private readonly IModel _channel;

        public ProducerController(Factory factory, IRabbitMqProducer rabbitMqProducer)
        {
            _rabbitMqProducer = rabbitMqProducer;
            _channel = factory.Create();
        }
        [HttpPost(Name = "Producer with factory")]
        public ActionResult Post(Form message)
        {
            new Thread(() => QueueProducer.Publish(_channel,message)).Start();
            new Thread(() => QueueConsumer.Consume(_channel)).Start();

            return Ok();
        }

        [HttpPost("add Product")]
        public IActionResult AddProduct()
        {
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabbitMqProducer.SendProductMessage(new{id=1,name="Apple",count=20});

            return Ok();
        }
    }
}
