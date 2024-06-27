using HospitalManagement.Application.Abstractions.Token;
using HospitalManagement.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
