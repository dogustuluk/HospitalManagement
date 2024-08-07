namespace HospitalManagement.Application.Services
{
    public class UserRegistrationStrategyFactoryService
    {
        public IUserRegistrationStrategyService GetRegisterStrategy(int userType)
        {
            return userType switch
            {
                2 => new PatientUserRegistrationStrategyService(),
                5 => new ExaminationAppointmentUserRegistrationStrategyService(),
                6 => new VisitorAppointmentUserRegistrationStrategyService(),
                _ => new DefaultUserRegistrationStrategyService()
            };
        }
    }
}
