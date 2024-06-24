using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Application.Specifications;
using MediatR;

namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQueryRequest, List<OptResult<GetAllDepartmentQueryResponse>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly DepartmentSpecifications _departmentSpecifications;

        public GetAllDepartmentQueryHandler(IDepartmentService departmentService, DepartmentSpecifications departmentSpecifications)
        {
            _departmentService = departmentService;
            _departmentSpecifications = departmentSpecifications;
        }

        public async Task<List<OptResult<GetAllDepartmentQueryResponse>>> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _departmentSpecifications.GetPredicate(request);

            var departments = await _departmentService.GetAllDepartment(predicate, "");

            var responseList = departments.Select(d => new GetAllDepartmentQueryResponse
            {
                DepartmentName = d.DepartmentName,
                DepartmentCode = d.DepartmentCode,
                isActive = d.isActive
            }).ToList();
            var resultList = responseList.Select(r => OptResult<GetAllDepartmentQueryResponse>.Success(r)).ToList();
            return resultList;
        }
    }
}
