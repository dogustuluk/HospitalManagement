using HospitalManagement.Application.DTOs;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}