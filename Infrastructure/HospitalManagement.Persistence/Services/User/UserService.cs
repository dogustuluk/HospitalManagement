using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.Common.DTOs.User;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.User
{
    [Service(ServiceLifetime.Scoped)]
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateUser_Dto>> CreateAsync(CreateUser_Dto model)
        {
            var appUser = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
            
            OptResult<CreateUser_Dto> response = new() { Succeeded = result.Succeeded};

            if (result.Succeeded)
            {
                response.Code = 200; //200?204?
                response.Data = _mapper.Map<CreateUser_Dto>(appUser);
            }
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code}-{error.Description}\n";

            return response;
        }
        
        public async Task<OptResult<UpdateUser_Dto>> UpdateAsync(UpdateUser_Dto model)
        {
            return null;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user == null)
                throw new ArgumentException(); //custom yap
            user.RefreshToken= refreshToken;
            user.RefreshTokenEndDate= accessTokenDate.AddSeconds(addOnAccessTokenDate);
            await _userManager.UpdateAsync(user);
        }
    }
}
