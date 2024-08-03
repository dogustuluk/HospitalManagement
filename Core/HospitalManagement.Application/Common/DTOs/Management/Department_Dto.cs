namespace HospitalManagement.Application.Common.DTOs.Management
{
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
}
