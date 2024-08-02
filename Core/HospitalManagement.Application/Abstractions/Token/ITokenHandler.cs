using HospitalManagement.Domain.Entities.Identity;

namespace HospitalManagement.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int hour, AppUser appUser);
        string CreateRefreshToken();
    }
}
