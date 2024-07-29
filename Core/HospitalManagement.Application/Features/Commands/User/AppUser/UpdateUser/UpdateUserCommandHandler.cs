using AutoMapper;
using HospitalManagement.Application.Abstractions.Security;
using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Application.Repositories;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, OptResult<UpdateUserCommandResponse>>
    {
        public readonly IUserService _userService;
        public readonly IAppUserReadRepository _appUserReadRepository;
        public readonly IMapper _mapper;
        private readonly ICryptographyService _cryptoHelperService;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper, ICryptographyService cryptoHelperService, IAppUserReadRepository appUserReadRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _cryptoHelperService = cryptoHelperService;
            _appUserReadRepository = appUserReadRepository;
        }

        public async Task<OptResult<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateUserDto = _mapper.Map<UpdateUser_Dto>(request);

            var a = await _appUserReadRepository.GetByGuidAsync(request.Guid);
            return null;
        }
    }
}
