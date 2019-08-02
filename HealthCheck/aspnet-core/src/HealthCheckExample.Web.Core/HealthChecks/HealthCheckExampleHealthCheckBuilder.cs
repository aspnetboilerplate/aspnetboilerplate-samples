using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckExample.HealthChecks
{
    public static class HealthCheckExampleHealthCheckBuilder
    {
        public static IHealthChecksBuilder AddHealthCheckExampleHealthChecks(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();

            builder.AddCheck<HealthCheckExampleDbContextCheck>("HealthCheckExampleDbContextCheck");

            builder.AddUrlGroup(new Uri("https://api.simplecast.com/v1/podcasts.json"), "Simplecast API Unhealthy Default", HealthStatus.Unhealthy);
            builder.AddUrlGroup(new Uri("https://api.simplecast.com/v1/podcasts.json"), "Simplecast API Degraded Default", HealthStatus.Degraded); //if this checks fail it will return degraded instead of Unhealthy
            builder.AddUrlGroup(new Uri("https://rss.simplecast.com/podcasts/4669/rss"), "Simplecast RSS");
            builder.AddUrlGroup(new Uri("https://jsonplaceholder.typicode.com/todos"), "My Todo Api", HealthStatus.Degraded);//suppose this is a micro-service endpoint you use in your project.
            
            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
