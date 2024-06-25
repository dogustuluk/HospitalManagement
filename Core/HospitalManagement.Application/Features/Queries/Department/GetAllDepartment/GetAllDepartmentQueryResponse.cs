namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryResponse
    {
        public int PageIndex { get; set; }
        public string? SearchText { get; set; }
        public int ParentID { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public bool isActive { get; set; } = true;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; }
    }
}