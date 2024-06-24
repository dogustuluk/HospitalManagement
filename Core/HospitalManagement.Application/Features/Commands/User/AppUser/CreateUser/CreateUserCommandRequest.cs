using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<OptResult<CreateUserCommandResponse>>
    {
        public string Guid { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}