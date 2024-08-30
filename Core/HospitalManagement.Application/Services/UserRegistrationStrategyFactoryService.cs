namespace HospitalManagement.Application.Services
{
    public class UserRegistrationStrategyFactoryService
    {
        private readonly IServiceProvider _serviceProvider;

        public UserRegistrationStrategyFactoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserRegistrationStrategyService GetRegisterStrategy(int userType)
        {
            return userType switch
            {
                //2 => new PatientUserRegistrationStrategyService(),
                2 => _serviceProvider.GetRequiredService<PatientUserRegistrationStrategyService>(),
                5 => new ExaminationAppointmentUserRegistrationStrategyService(),
                6 => new VisitorAppointmentUserRegistrationStrategyService(),
                _ => new DefaultUserRegistrationStrategyService()
            };
        }
    }
}
