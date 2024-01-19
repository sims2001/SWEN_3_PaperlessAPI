using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperLess.Queue.Interfaces;

namespace PaperLess.ServiceAgents.Queue {

    public class QueueConsumerService : BackgroundService
    {
        private readonly IQueueConsumer _queueConsumer;
        private readonly ILogger<QueueConsumerService> _logger;

        public QueueConsumerService(IOptions<QueueOptions> options, IQueueConsumer queueConsumer, ILogger<QueueConsumerService> logger)
        {
            _queueConsumer = queueConsumer;
            _logger = logger;
            _queueConsumer.OnReceived += OnReceived;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queue Consumer Service is starting.");

            // Start the message consumption loop
            _queueConsumer.StartReceive();

            // Keep the service running until it's canceled
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken); // Add a delay to avoid a tight loop
            }

            _logger.LogInformation("Queue Consumer Service is stopping.");

            // Stop the message consumption when the service is canceled
            _queueConsumer.StopReceive();
        }

        private void OnReceived(object sender, QueueReceivedEventArgs eventArgs)
        {
            // Handle the received message as needed
            var receivedMessage = eventArgs.Content;
            _logger.LogInformation($"Received message: {receivedMessage}");

            _logger.LogInformation($"I am Working OCR Magic HERE!");
        }
    }

}