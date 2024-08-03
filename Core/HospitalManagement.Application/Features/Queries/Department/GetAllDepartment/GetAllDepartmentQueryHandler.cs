namespace HospitalManagement.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQueryRequest, OptResult<IQueryable<GetAllDepartmentQueryResponse>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly DepartmentSpecifications _departmentSpecifications;
        private readonly IMapper _mapper;

        public GetAllDepartmentQueryHandler(IDepartmentService departmentService, DepartmentSpecifications departmentSpecifications, IMapper mapper)
        {
            _departmentService = departmentService;
            _departmentSpecifications = departmentSpecifications;
            _mapper = mapper;
        }

        public async Task<OptResult<IQueryable<GetAllDepartmentQueryResponse>>> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _departmentSpecifications.GetPredicate(request);
            
            var departments = await _departmentService.GetAllDepartment(predicate, "");

            if (string.IsNullOrEmpty(request.OrderBy))
                request.OrderBy = "SortOrderNo ASC";

            var responseList = _mapper.ProjectTo<GetAllDepartmentQueryResponse>(departments.AsQueryable().OrderBy(request.OrderBy));

            return await OptResult<IQueryable<GetAllDepartmentQueryResponse>>.SuccessAsync(responseList, Messages.Successfull);
        }
    }
}
