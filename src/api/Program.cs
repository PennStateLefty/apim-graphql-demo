using ApimDemo.GraphQLResolver;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IMockFactory, MockFactory>((s) => {
            var factory = MockFactory.Instance;
            factory.LoadMockData();
            return factory;
        });
        
        services.AddApplicationInsightsTelemetryWorkerService().ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();