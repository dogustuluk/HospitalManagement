namespace HospitalManagement.Domain.Entities.Identity
{
    public class AppRolePermission : BaseEntity
    {
        public int AppRoleAuthorityId { get; set; }
        public int? ParentPermissionId { get; set; }
        public string PermissionName { get; set; }
        public int PermissionLevel { get; set; }
        public int isActive { get; set; }


        public virtual AppRoleAuthority AppRoleAuthority { get; set; }
        public virtual AppRolePermission ParentPermission { get; set; }
        public virtual ICollection<AppRolePermission> ChildPermissions { get; set; }


    }
}
