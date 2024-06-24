using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryRequest : IRequest<List<OptResult<GetAllDepartmentQueryResponse>>>
    {
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
    }
}