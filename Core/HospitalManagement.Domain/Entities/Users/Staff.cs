using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Domain.Entities.Users
{
    public class Staff : BaseEntity
    {
        public string AppUserId { get; set; }
        public int DepartmentId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
