using PaperLess.ServiceAgents.Queue;
using PaperLess.Queue.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddLogging(builder => {
    builder.AddConsole();
});

builder.Services.Configure<QueueOptions>(options =>
{
    options.ConnectionString = "amqp://paperless:paperless@paperless-queue";
    options.QueueName = "paperless-queue";
});

builder.Services.AddSingleton<IQueueConsumer, QueueConsumer>();

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
