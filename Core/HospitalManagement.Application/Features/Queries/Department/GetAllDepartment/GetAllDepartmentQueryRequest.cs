using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryRequest : IRequest<OptResult<IQueryable<GetAllDepartmentQueryResponse>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ParentID { get; set; }
        public int ManagerMemberId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
        public string? OrderBy { get; set; } = "DepartmentName ASC";
    }
}