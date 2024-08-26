namespace HospitalManagement.Domain.Entities.Identity
{
    public class AppUserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual AppRole AppRole { get; set; }

    }
}
