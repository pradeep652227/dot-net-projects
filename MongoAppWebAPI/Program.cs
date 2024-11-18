using MongoAppWebAPI.Context;
using MongoAppWebAPI.Models;
using MongoAppWebAPI.Registries;
using MongoAppWebAPI.Services.Abstraction;
using MongoAppWebAPI.Services.Implementation;
using StackExchange.Redis;
using Microsoft.Extensions.Caching.Distributed;
var builder = WebApplication.CreateBuilder(args);

// Configure logging providers
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Log to console
builder.Logging.AddDebug();   // Log to debug output window (useful in development)



// Add services to the container.
var Services =builder.Services;

CoreModule.Register(Services);
Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
Services.AddControllers();

Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();




// Retrieve the Redis connection string
var redisConnectionString = builder.Configuration.GetSection("Redis")["ConnectionString"];
if (string.IsNullOrEmpty(redisConnectionString))
{
    throw new ArgumentNullException("Redis connection string is missing.");
}


//Redis Service
Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionString;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//GraphQL Middleware Configuration
// Use GraphQL middleware

// Optionally add GraphQL playground for testing queries
//app.UseGraphQLPlayground("/ui/playground");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
