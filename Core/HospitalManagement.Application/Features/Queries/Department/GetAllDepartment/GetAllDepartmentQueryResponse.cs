namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryResponse
    {
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
        public bool? isActive{ get; set; }
    }
}