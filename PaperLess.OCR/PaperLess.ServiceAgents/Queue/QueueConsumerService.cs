using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Minio;
using Minio.DataModel.Args;
using PaperLess.Queue.Interfaces;
using PaperLess.ServiceAgents.Interfaces;
using PaperLess.ServiceAgents.DBConnection;

namespace PaperLess.ServiceAgents.Queue {

    public class QueueConsumerService : BackgroundService
    {
        private readonly IQueueConsumer _queueConsumer;
        private readonly IMinioClient _minioClient;
        private readonly IOcrClient _ocrClient;
        private readonly PaperLessDbContext _dbContext;
        private readonly ILogger<QueueConsumerService> _logger;

        public QueueConsumerService(IQueueConsumer queueConsumer, IMinioClient minioClient, IOcrClient ocrClient, PaperLessDbContext dbContext, ILogger<QueueConsumerService> logger)
        {
            _queueConsumer = queueConsumer;
            _minioClient = minioClient;
            _ocrClient = ocrClient;
            _dbContext = dbContext;
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

        private async void OnReceived(object sender, QueueReceivedEventArgs eventArgs)
        {
            // Handle the received message as needed
            var receivedMessage = eventArgs.Content;
            _logger.LogInformation($"Received message: {receivedMessage}");

            var queueContent = JsonConvert.DeserializeObject<QueueContent>(receivedMessage);

            _logger.LogInformation($"I am Working MinIO Magic HERE!");
            var documentStream = await GetMinIOFileContent(queueContent.UploadedName);

            _logger.LogInformation($"I am Working OCR Magic HERE!");

            var ocrContent = _ocrClient.PerformOcrPdf(documentStream);

            _logger.LogInformation($"DoneWithOCR");
            _logger.LogInformation(ocrContent);
            
            var theDoc = await _dbContext.Documents.FindAsync(queueContent.DocumentId);
            theDoc.Content = ocrContent;
            await _dbContext.SaveChangesAsync();
            //HIER NOCH SHIT IN DIE DATENBANK BZW ERROR HANDLING UND ALLES TUTI BUENE!!!
        }

        private async Task<FileStream?> GetMinIOFileContent(string filename){
            string bucketName = "paperless-bucket";
            string filePath = Path.Combine("../", filename);
            try
            {
                var statObjArgs = new StatObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(filename);
                var statObjectResponse = await _minioClient.StatObjectAsync(statObjArgs);

                if (statObjectResponse != null)
                {
                    var getObjArgs = new GetObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(filename)
                        .WithCallbackStream((stream) =>
                        {
                            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fileStream);
                            }
                        });

                    await _minioClient.GetObjectAsync(getObjArgs);

                    return new FileStream(filePath, FileMode.Open);
                }
                else
                {
                    Console.WriteLine($"The given Object: '{filename}' is not existing in the given bucket: '{bucketName}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                throw;
            }
            return null;

        }
    }

}