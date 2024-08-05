namespace HospitalManagement.Application.Features.Queries.Department.GetDataPagedList
{
    public class GetDataPagedListQueryHandler : IRequestHandler<GetDataPagedListQueryRequest, OptResult<PaginatedList<GetDataPagedListQueryResponse>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly DepartmentSpecifications _departmentSpecifications;
        private readonly IMapper _mapper;

        public GetDataPagedListQueryHandler(IDepartmentService departmentService, IMapper mapper, DepartmentSpecifications departmentSpecifications, IDepartmentReadRepository departmentReadRepository)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _departmentSpecifications = departmentSpecifications;
            _departmentReadRepository = departmentReadRepository;
        }
        //eksik
        public async Task<OptResult<PaginatedList<GetDataPagedListQueryResponse>>> Handle(GetDataPagedListQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _departmentSpecifications.GetDataPagedListPredicate(request);

            if (string.IsNullOrEmpty(request.OrderBy))
                request.OrderBy = "DepartmentName ASC";

            var pagedDepartments = await _departmentReadRepository.GetDataPagedAsync(predicate, "", request.PageIndex, request.Take, request.OrderBy);

            var responsePagedDataList = _mapper.Map<PaginatedList<GetDataPagedListQueryResponse>>(pagedDepartments);

            return await OptResult<PaginatedList<GetDataPagedListQueryResponse>>.SuccessAsync(responsePagedDataList, Messages.Successfull);

        }
    }
}