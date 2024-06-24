using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Management
{
    public class Department : BaseEntity
    {
        public int ParentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public bool isActive { get; set; }
    }
}
