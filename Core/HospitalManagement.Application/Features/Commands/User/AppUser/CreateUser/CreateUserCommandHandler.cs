namespace HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, OptResult<CreateUserCommandResponse>>
    {
        private readonly IUserService _userService;
        private readonly ICryptographyService _cryptoHelperService;
        private readonly IMapper _mapper;
        private readonly UserRegistrationStrategyFactoryService _strategyFactory;

        public CreateUserCommandHandler(IUserService userService, ICryptographyService cryptoHelperService, IMapper mapper, UserRegistrationStrategyFactoryService strategyFactory)
        {
            _userService = userService;
            _cryptoHelperService = cryptoHelperService;
            _mapper = mapper;
            _strategyFactory = strategyFactory;
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
                    var appUser = _mapper.Map<Domain.Entities.Identity.AppUser>(createdUser.Data);
                    var strategy = _strategyFactory.GetRegisterStrategy(appUser.UserType);
                    await strategy.ExecuteAsync(appUser,request.PatientUser);

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
