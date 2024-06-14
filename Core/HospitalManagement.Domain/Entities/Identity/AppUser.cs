using HospitalManagement.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {

        public string NameSurname { get; set; }
        public string? Gender { get; set; }
        public string? IdentityNo { get; set; }
        public string? GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public string? Email { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int StatusId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserDetailsJSON { get; set; }
        public int? Experience { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }


        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
