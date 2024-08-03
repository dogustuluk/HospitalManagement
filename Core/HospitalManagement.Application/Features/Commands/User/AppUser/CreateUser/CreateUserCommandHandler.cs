namespace HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, OptResult<CreateUserCommandResponse>>
    {
        private readonly IUserService _userService;
        private readonly ICryptographyService _cryptoHelperService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, ICryptographyService cryptoHelperService, IMapper mapper)
        {
            _userService = userService;
            _cryptoHelperService = cryptoHelperService;
            _mapper = mapper;
        }
       
        public async Task<OptResult<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            OptResult<CreateUserCommandResponse> response = new OptResult<CreateUserCommandResponse>();
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var createUserDto = _mapper.Map<CreateUser_Dto>(request);
                createUserDto.IdentityNo = await _cryptoHelperService.EncryptString(request.IdentityNo);
               
                var createdUser = await _userService.CreateAsync(createUserDto);
                if (createdUser.Succeeded)
                {
                    response.Succeeded = true;
                    response.Data = _mapper.Map<CreateUserCommandResponse>(createdUser.Data);
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "User creation failed.";
                }
                return response;
            });
        }
    }
}
