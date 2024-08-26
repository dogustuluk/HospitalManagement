namespace HospitalManagement.Domain.Entities.Identity
{
    public class AppRoleAuthority : BaseEntity
    {
        public int AppRoleId { get; set; }
        public bool isCanView { get; set; }
        public bool isCanSeeAll { get; set; }
        public bool isCanInsert { get; set; }
        public bool isCanApprove { get; set; }
        public bool isCanUpdate { get; set; }
        public bool isCanDelete { get; set; }
        public bool isActive { get; set; }

        public virtual AppRole AppRole { get; set; }
        public virtual ICollection<AppRolePermission> RolePermissions { get; set; }


    }
}
