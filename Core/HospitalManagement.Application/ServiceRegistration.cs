using HospitalManagement.Application.Utilities.Security.Resiliance;
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
            serviceCollection.AddScoped<DbParameterSpecifications>();
            serviceCollection.AddScoped<DbParameterTypeSpecifications>();
            serviceCollection.AddScoped<RoomSpecifications>();
            serviceCollection.AddScoped<UserSpecifications>();
            serviceCollection.AddScoped<ErrorSpecifications>();
            serviceCollection.AddScoped<AnnouncementSpecifications>();
            serviceCollection.AddScoped<MedicineSpecifications>();
            serviceCollection.AddScoped<HospitalSpecifications>();
            serviceCollection.AddScoped<AppointmentSpecifications>();
            serviceCollection.AddScoped<DepartmentSpecifications>();
            serviceCollection.AddScoped<UserRegistrationStrategyFactoryService>();
            serviceCollection.AddScoped<ICryptographyService,CryptographyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DefaultUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DoctorUserRegistrationStrategyService>();

            serviceCollection.AddScoped<PatientUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, PatientUserRegistrationStrategyService>();

            serviceCollection.AddScoped<IUserRegistrationStrategyService, VisitorAppointmentUserRegistrationStrategyService>();

        }
    }
}