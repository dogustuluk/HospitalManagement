using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Application.Repositories;
using HospitalManagement.Application.Settings;
using HospitalManagement.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.User
{
    [Service(ServiceLifetime.Scoped)]
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OptResult<CreateUser_Dto>> CreateAsync(CreateUser_Dto model)
        {
            var appUser = new AppUser
            {
                Guid = Guid.NewGuid(),
                UserType = model.UserType,
                NameSurname = model.NameSurname,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                IdentityNo = model.IdentityNo,
                GSM = model.GSM,
                GSMPersonal = model.GSMPersonal,
                UserDetailsJSON = model.UserDetailsJSON,
                Address = model.Address,
                CountyId = model.CountyId,
                CityId = model.CityId,
                BirthDate= model.BirthDate,
                Experience = model.Experience,
                StatusId = 10
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
            
            OptResult<CreateUser_Dto> response = new() { Succeeded = result.Succeeded};

            if (result.Succeeded)
            {
                response.Code = 200;

                response.Data = new CreateUser_Dto()
                {
                    Guid = appUser.Guid,
                    Email = model.Email,
                    NameSurname = model.NameSurname,
                    UserName = model.UserName,
                };
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
