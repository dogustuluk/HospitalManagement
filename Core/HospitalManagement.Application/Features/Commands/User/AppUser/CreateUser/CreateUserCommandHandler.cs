using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, OptResult<CreateUserCommandResponse>>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<OptResult<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            OptResult<CreateUserCommandResponse> response = new OptResult<CreateUserCommandResponse>();
            try
            {
                OptResult<CreateUser_Dto> createUserDto = await _userService.CreateAsync(new CreateUser_Dto
                {
                    NameSurname = request.NameSurname,
                    Password = request.Password,
                    PasswordConfirm = request.PasswordConfirm,
                    UserName = request.UserName,
                    Guid = Guid.NewGuid().ToString(),
                    Email = request.Email,
                });

                if (createUserDto != null)
                {
                    response.Succeeded = true;
                    response.Data = new CreateUserCommandResponse
                    {
                        Id = createUserDto.Data.Guid,
                        UserName = createUserDto.Data.UserName,
                        Email = createUserDto.Data.Email
                    };
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "User creation failed.";
                }
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }
    }
}
