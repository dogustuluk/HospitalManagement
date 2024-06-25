using FluentValidation;
using HospitalManagement.Application.Abstractions.Security;
using HospitalManagement.Application.Services;
using HospitalManagement.Application.Specifications;
using HospitalManagement.Application.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HospitalManagement.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ServiceRegistration));
            serviceCollection.AddHttpClient();
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            

            //otomatize et -->
            serviceCollection.AddScoped<DepartmentSpecifications>();
            serviceCollection.AddScoped<ICryptographyService,CryptographyService>();
        }
    }
}