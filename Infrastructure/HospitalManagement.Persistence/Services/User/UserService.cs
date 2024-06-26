﻿using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.GenericObjects;
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
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                GSM = model.GSM,
                GSMPersonal = model.GSMPersonal,
                UserDetailsJSON = model.UserDetailsJSON,
                Address = model.Address,
                CountyId = 1,
                CityId = 35,
                StatusId = 10
            }, model.Password);

            OptResult<CreateUser_Dto> response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Code = 200;

                response.Data = new CreateUser_Dto()
                {
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
