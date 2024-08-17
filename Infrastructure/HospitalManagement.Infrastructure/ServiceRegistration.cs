using HospitalManagement.Application.Abstractions.Caching;
using HospitalManagement.Application.Abstractions.Token;
using HospitalManagement.Application.Services;
using HospitalManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace HospitalManagement.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();

            serviceCollection.AddTransient<IConnectionMultiplexer>(sp =>
            {
                var options = new ConfigurationOptions
                {
                    EndPoints = { configuration.GetConnectionString("RedisConnection") },
                    AbortOnConnectFail = false,
                    AsyncTimeout = 10000,
                    ConnectTimeout = 10000

                };
                return ConnectionMultiplexer.Connect(options);
            });
            serviceCollection.AddScoped<IRedisCacheService, RedisCacheService>();

        }
    }
}
