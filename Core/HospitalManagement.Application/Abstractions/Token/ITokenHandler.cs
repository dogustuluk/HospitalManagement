namespace HospitalManagement.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Common.DTOs.Token CreateAccessToken(int hour, AppUser appUser);
        string CreateRefreshToken();
    }
}
