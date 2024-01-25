using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PaperLess.BusinessLogic;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.BusinessLogic.Validation;
using PaperLess.WebApi.OpenApi;
using PaperLess.WebApi.Filters;
using PaperLess.WebApi.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaperLess.BusinessLogic.Entities.Mapper;
using PaperLess.DataAccess.Interfaces;
using PaperLess.DataAccess.SQL;
using PaperLess.DataAccess.SQL.PostgresRepositories;
using Minio;
using Minio.Exceptions;
using Minio.DataModel.Args;
using PaperLess.Queue.Interfaces;
using PaperLess.BusinessLogic.Queue;
using PaperLess.DataAccess.Entities.Mapper;
using PaperLess.Elastic.Interfaces;
using PaperLess.WebApi.ElasticSearch;

namespace PaperLess.WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAutoMapper(typeof(ImportantRequestMapperProfile), typeof(DalModelMapperProfile), typeof(RestModelMapperProfile));

            services.AddSingleton<IMinioClient>(sp => {
                //.WithEndpoint("storage.min.io")
                var minioClient = new MinioClient().WithEndpoint("paperless-storage:9000").WithCredentials("paperless", "paperless").Build();

                EnsureBucketExists(minioClient, "paperless-bucket").GetAwaiter().GetResult();

                return minioClient;
            });

            services.AddLogging(builder => {
                builder.AddConsole();
            });

            services.AddDbContext<PaperLessDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
                //options.UseNpgsql(Configuration.GetConnectionString("PostgresDev")));

            services.Configure<QueueOptions>(options => {
                options.ConnectionString = "amqp://paperless:paperless@paperless-queue";
                options.QueueName = "paperless-queue";
            });

            services.AddTransient<IQueueProducer, QueueProducer>();
            
            services.AddScoped<IElasticSearcher, ElasticSearcher>();

            services.AddScoped<IValidator<Tag>, TagValidator>();
            services.AddScoped<IValidator<Correspondent>, CorrespondentValidator>();
            services.AddScoped<IValidator<Document>, DocumentValidator>();
            services.AddScoped<IValidator<DocumentType>, DocumentTypeValidator>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICorrespondentRepository, CorrespondentRepository>();

            services.AddScoped<ITagLogic, TagLogic>();
            services.AddScoped<IDocumentLogic, DocumentLogic>();
            services.AddScoped<IDocumentTypeLogic, DocumentTypeLogic>();
            services.AddScoped<ICorrespondentLogic, CorrespondentLogic>();
            services.AddScoped<ISearchLogic, SearchLogic>();

            // Add framework services.
            services
                // Don't need the full MVC stack for an API, see https://andrewlock.net/comparing-startup-between-the-asp-net-core-3-templates/
                .AddControllers(options => {
                    options.InputFormatters.Insert(0, new InputFormatterStream());
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    });
                });
            services
                .AddSwaggerGen(c =>
                {
                    c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                    
                    c.SwaggerDoc("1.0", new OpenApiInfo
                    {
                        Title = "PaperLess API",
                        Description = "PaperLess API (ASP.NET Core 6.0)",
                        TermsOfService = new Uri("https://github.com/openapitools/openapi-generator"),
                        Contact = new OpenApiContact
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = new Uri("https://github.com/openapitools/openapi-generator"),
                            Email = ""
                        },
                        License = new OpenApiLicense
                        {
                            Name = "NoLicense",
                            Url = new Uri("http://localhost")
                        },
                        Version = "1.0",
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as OpenAPI validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
                services
                    .AddSwaggerGenNewtonsoftSupport();


        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PaperLessDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            dbContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseSwagger(c =>
                {
                    c.RouteTemplate = "openapi/{documentName}/openapi.json";
                })
                .UseSwaggerUI(c =>
                {
                    // set route prefix to openapi, e.g. http://localhost:8080/openapi/index.html
                    c.RoutePrefix = "openapi";
                    //TODO: Either use the SwaggerGen generated OpenAPI contract (generated from C# classes)
                    c.SwaggerEndpoint("/openapi/1.0/openapi.json", "Mock Server");

                    //TODO: Or alternatively use the original OpenAPI contract that's included in the static files
                    // c.SwaggerEndpoint("/openapi-original.json", "Mock Server Original");
                });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        private async Task EnsureBucketExists(IMinioClient minio, string bucketName)
        {
            try {
                var foundArgs = new BucketExistsArgs().WithBucket(bucketName);

                Console.WriteLine("Trying to find Bucket");

                var found = await minio.BucketExistsAsync(foundArgs);
                var fndString = "Found: " + found.ToString();
                Console.WriteLine(fndString);
                if (!found) {
                    // Create the bucket if it doesn't exist
                    Console.WriteLine("Didnt find Bucket");
                    var makeArgs = new MakeBucketArgs().WithBucket(bucketName);
                    await minio.MakeBucketAsync(makeArgs);
                }
            }
            catch (MinioException e) {
                Console.WriteLine($"Bucket Error: {e.Message}");
            }
        }

    }
}
