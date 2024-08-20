using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Domain.Entities.Management;

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
           // serviceCollection.AddScoped<GenericSpecification<Department>>();
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