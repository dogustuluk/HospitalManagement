using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Domain.Entities.Identity;

namespace HospitalManagement.Application.Abstractions.Services.Users
{
    public interface IUserService
    {
        Task<OptResult<CreateUser_Dto>> CreateAsync(CreateUser_Dto model);
        Task<OptResult<UpdateUser_Dto>> UpdateAsync(UpdateUser_Dto model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
