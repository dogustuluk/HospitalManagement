using HospitalManagement.Application.Message.Consumers.Appointment;
using HospitalManagement.Application.Utilities.Security.Resiliance;
using MassTransit;
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
            serviceCollection.AddScoped<ICryptographyService, CryptographyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DefaultUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, DoctorUserRegistrationStrategyService>();

            serviceCollection.AddScoped<PatientUserRegistrationStrategyService>();
            serviceCollection.AddScoped<IUserRegistrationStrategyService, PatientUserRegistrationStrategyService>();

            serviceCollection.AddScoped<IUserRegistrationStrategyService, VisitorAppointmentUserRegistrationStrategyService>();


            //massTransit konfigürasyonları
            serviceCollection.AddMassTransit(a =>
            {
                a.AddConsumer<CreateAppointmentConsumer>();
                a.AddConsumer<CreateAppointmentEventConsumer>();

                a.UsingRabbitMq((context, _config) =>
                {
                    _config.Host("amqps://zsipeopu:ICYmOGZN9EQScGYni3JQB2z2bnRAxWV5@possum.lmq.cloudamqp.com/zsipeopu");

                    _config.ReceiveEndpoint(RabbitMQSettings.Appointment_CreateAppointmentQueue, e =>
                    {
                        e.ConfigureConsumer<CreateAppointmentConsumer>(context);
                    });

                    _config.ReceiveEndpoint(RabbitMQSettings.ServiceLog_EventQueue, e =>
                    {
                        e.ConfigureConsumer<CreateAppointmentEventConsumer>(context);
                    });
                });
            });

        }
    }
}