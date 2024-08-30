using HospitalManagement.Application.Common.GenericObjects;

namespace HospitalManagement.Client.Models.Management
{
    public class Create_Department_ViewModel
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
    public class Department_Index_ViewModel
    {
        public string? PageTitle { get; set; }
        public string? SubPageTitle { get; set; }
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ParentID { get; set; } = -99;
        public int ManagerMemberID { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";

        public IList<Department_GridData_ViewModel>? MyGridData { get; set; }
        public Pagination? MyPagination { get; set; }
    }
    public class Department_GridData_ViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int ParentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public bool isActive { get; set; }
    }
}
