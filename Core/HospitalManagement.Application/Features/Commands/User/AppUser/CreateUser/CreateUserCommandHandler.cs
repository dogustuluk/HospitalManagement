﻿using AutoMapper;
using HospitalManagement.Application.Abstractions.Security;
using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.Extensions;
using HospitalManagement.Application.GenericObjects;
using MediatR;

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
                createUserDto.Guid = Guid.NewGuid().ToString();
                createUserDto.IdentityNo = await _cryptoHelperService.EncryptString(request.IdentityNo);
               
                var createdUser = await _userService.CreateAsync(createUserDto);
                if (createUserDto != null)
                {
                    response.Succeeded = true;
                    response.Data = new CreateUserCommandResponse
                    {
                        Id = createUserDto.Guid,
                        UserName = createUserDto.UserName,
                        Email = createUserDto.Email,
                        GSM = createUserDto.GSM,
                    };
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
