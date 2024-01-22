using PaperLess.ServiceAgents.Queue;
using PaperLess.Queue.Interfaces;
using Minio;
using Minio.Exceptions;
using Minio.DataModel.Args;
using PaperLess.ServiceAgents.Interfaces;
using PaperLess.ServiceAgents.OCR;
using PaperLess.ServiceAgents.DBConnection;
using Microsoft.EntityFrameworkCore;
using PaperLess.Elastic.Interfaces;
using PaperLess.ServiceAgents.ElasticSearch;

async Task EnsureBucketExists(IMinioClient minio, string bucketName) {
    try
    {
        var foundArgs = new BucketExistsArgs().WithBucket(bucketName);

        Console.WriteLine("Trying to find Bucket");

        var found = await minio.BucketExistsAsync(foundArgs);
        var fndString = "Found: " + found.ToString();
        Console.WriteLine(fndString);
        if (!found)
        {
            // Create the bucket if it doesn't exist
            Console.WriteLine("Didnt find Bucket");
            var makeArgs = new MakeBucketArgs().WithBucket(bucketName);
            await minio.MakeBucketAsync(makeArgs);
        }
    }
    catch (MinioException e)
    {
        Console.WriteLine($"Bucket Error: {e.Message}");
    }
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddLogging(builder => {
    builder.AddConsole();
});

builder.Services.AddDbContext<PaperLessDbContext>(options => 
    options.UseNpgsql("Host=paperless-db;Database=paperless;Username=paperless;Password=paperless"));

builder.Services.Configure<QueueOptions>(options =>
{
    options.ConnectionString = "amqp://paperless:paperless@paperless-queue";
    options.QueueName = "paperless-queue";
});


builder.Services.AddSingleton<IMinioClient>(sp =>
{
    //.WithEndpoint("storage.min.io")
    var minioClient = new MinioClient().WithEndpoint("paperless-storage:9000").WithCredentials("paperless", "paperless").Build();

    EnsureBucketExists(minioClient, "paperless-bucket").GetAwaiter().GetResult();

    return minioClient;
});

builder.Services.AddSingleton<IQueueConsumer, QueueConsumer>();

builder.Services.AddSingleton<IElasticAdder, ElasticAdder>();

builder.Services.AddTransient<IOcrClient, OcrClient>(sp => new OcrClient(new OcrOptions()));

builder.Services.AddHostedService<QueueConsumerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
