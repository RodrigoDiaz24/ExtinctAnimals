using ExtinctAnimals.Application.Interfaces;
using ExtinctAnimals.Application.Services;
using ExtinctAnimals.Infrastructure.Configuration;
using ExtinctAnimals.Infrastructure.Http;
using ExtinctAnimals.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ExtinctAnimals.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configure ExtinctAnimalsApiOptions
            services.Configure<ExtinctAnimalsApiOptions>(
                configuration.GetSection(ExtinctAnimalsApiOptions.SectionName));
            // Register ExtinctAnimalsApiClient
            services.AddHttpClient<ExtinctAnimalsApiClient>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<ExtinctAnimalsApiOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
            });

            // Register repositories and services
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
