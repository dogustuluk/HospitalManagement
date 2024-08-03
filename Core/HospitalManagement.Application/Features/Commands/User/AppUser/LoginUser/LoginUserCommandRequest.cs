namespace HospitalManagement.Application.Features.Commands.User.AppUser.LoginUser
{
    public class LoginUserCommandRequest : IRequest<OptResult<LoginUserCommandResponse>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}