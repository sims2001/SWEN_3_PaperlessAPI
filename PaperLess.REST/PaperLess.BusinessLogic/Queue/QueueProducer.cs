using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperLess.Queue.Interfaces;
using RabbitMQ.Client;

namespace PaperLess.BusinessLogic.Queue {

    public class QueueProducer : QueueClient, IQueueProducer
    {
        private readonly ILogger<QueueProducer> _logger;

        public QueueProducer(IOptions<QueueOptions> options, ILogger<QueueProducer> logger) : base(options.Value.ConnectionString, options.Value.QueueName)
        {
            _logger = logger;
        }


        public void PublishToQueue(string body) {

            IBasicProperties properties = base.RabbitMqChannel.CreateBasicProperties();

            base.RabbitMqChannel.BasicPublish(exchange: ExchangeName,
                                         routingKey: $"{QueueName}.*",
                                         mandatory: false,
                                         basicProperties: properties,
                                         body: System.Text.Encoding.UTF8.GetBytes(body));

        }
    }

}