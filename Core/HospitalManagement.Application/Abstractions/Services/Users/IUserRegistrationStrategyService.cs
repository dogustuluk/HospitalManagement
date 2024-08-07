namespace HospitalManagement.Application.Abstractions.Services.Users
{
    public interface IUserRegistrationStrategyService
    {
        Task ExecuteAsync(AppUser user);
    }
}
