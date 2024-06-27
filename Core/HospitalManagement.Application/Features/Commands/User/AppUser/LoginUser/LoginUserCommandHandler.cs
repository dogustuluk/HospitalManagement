using HospitalManagement.Application.Abstractions.Services.Auth;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IInternalAuthentication _internalAuthentication;

        public LoginUserCommandHandler(IInternalAuthentication internalAuthentication)
        {
            _internalAuthentication = internalAuthentication;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _internalAuthentication.LoginAsync(request.UsernameOrEmail, request.Password, 900);
            return new LoginUserSuccessCommandResponse() { Token = token };
        }
    }
}
