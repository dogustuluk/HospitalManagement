using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Utilities.Security.Resiliance;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.Extensions.Hosting;

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
            serviceCollection.AddTransient<IResiliencePolicyProvider, ResiliencePolicyProvider>();
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ResilianceBehavior<,>));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            //otomatize et -->
            // serviceCollection.AddScoped<GenericSpecification<Department>>();
            serviceCollection.AddSingleton<IHostedService, CityCacheHostedService>();
            serviceCollection.AddScoped<AnnouncementSpecifications>();
            serviceCollection.AddScoped<HospitalSpecifications>();
            serviceCollection.AddScoped<AppointmentSpecifications>();
            serviceCollection.AddScoped<DepartmentSpecifications>();
            serviceCollection.AddScoped<UserRegistrationStrategyFactoryService>();
            serviceCollection.AddScoped<ICryptographyService,CryptographyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DefaultUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DoctorUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, PatientUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, VisitorAppointmentUserRegistrationStrategyService>();


        }
    }
}