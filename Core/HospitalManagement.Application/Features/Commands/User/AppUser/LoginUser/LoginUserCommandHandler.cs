using HospitalManagement.Application.Abstractions.Services.Auth;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Extensions;
using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, OptResult<LoginUserCommandResponse>>

    {
        private readonly IInternalAuthentication _internalAuthentication;

        public LoginUserCommandHandler(IInternalAuthentication internalAuthentication)
        {
            _internalAuthentication = internalAuthentication;
        }

        public async Task<OptResult<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            //var token = await _internalAuthentication.LoginAsync(request.UsernameOrEmail, request.Password, 900);

            //return new LoginUserSuccessCommandResponse() { Token = token };
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var token = await _internalAuthentication.LoginAsync(request.UsernameOrEmail, request.Password, 900);

                if (token == null)
                {
                    return await OptResult<LoginUserCommandResponse>.FailureAsync(Messages.UnSuccessfull);
                }

                var response = new LoginUserCommandResponse() { Token = token };
                return await OptResult<LoginUserCommandResponse>.SuccessAsync(response);
            });

        }
    }
}
