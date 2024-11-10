using System;

namespace OrderingAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services) 
    {
        // services.AddCarter

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app) 
    {
        return app;
    }
}
