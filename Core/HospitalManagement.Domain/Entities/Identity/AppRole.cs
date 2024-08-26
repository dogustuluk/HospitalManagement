using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public bool isActive { get; set; }

        public virtual ICollection<AppRoleAuthority> RoleAuthorities { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

    }
}
