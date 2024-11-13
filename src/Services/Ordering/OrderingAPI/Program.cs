using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;
using OrderingAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    await app.InitialiseDatabaseAsync();
}

app.MapGet("/", () => "Hello World!");
app.UseApiServices();

app.Run();
