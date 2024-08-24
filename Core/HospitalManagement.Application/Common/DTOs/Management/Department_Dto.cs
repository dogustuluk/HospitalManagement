namespace HospitalManagement.Application.Common.DTOs.Management
{
    public class GetAllPaged_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ParentID { get; set; } = -99;
        public int ManagerMemberID { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public string? IDsColumn { get; set; }
        public string? IDsList { get; set; }
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
    public class GetAll_Department_Dto
    {
        //public int PageIndex { get; set; } = 1;
        //public string? SearchText { get; set; }
        public int ParentID { get; set; } = -99;
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public int isActive { get; set; } = 1;
        //public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "DepartmentName ASC";
    }

    public class Create_Department_Dto
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
    public class Update_Department_Dto
    {
        public Guid Guid { get; set; }
        public int ParentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public bool isActive { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
