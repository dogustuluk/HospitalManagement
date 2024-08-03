namespace HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, OptResult<UpdateUserCommandResponse>>
    {
        public readonly IUserService _userService;
        public readonly IAppUserReadRepository _appUserReadRepository;
        public readonly IAppUserWriteRepository _appUserWriteRepository;
        public readonly IMapper _mapper;
        private readonly ICryptographyService _cryptoHelperService;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper, ICryptographyService cryptoHelperService, IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _cryptoHelperService = cryptoHelperService;
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;
        }

        public async Task<OptResult<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            OptResult<UpdateUserCommandResponse> response = new OptResult<UpdateUserCommandResponse>();
            return await ExceptionHandler.HandleOptResultAsync(async() =>
            {
                var updatedUserDto = _mapper.Map<UpdateUser_Dto>(request);
                var myUser = await _appUserReadRepository.GetByEntityAsync(request.Value);
                if (myUser == null)
                {
                    return await OptResult<UpdateUserCommandResponse>.FailureAsync(Messages.UserNotFound);
                }

                _mapper.Map(updatedUserDto, myUser);
                //myUser.NameSurname = request.NameSurname;
                var result = await _appUserWriteRepository.SaveChanges();
                if (result > 0)
                {
                    response.Succeeded = true;
                    response.Data = _mapper.Map<UpdateUserCommandResponse>(myUser);
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = Messages.UnSuccessfull;
                }
                return response;
            });
        }
    }
}
