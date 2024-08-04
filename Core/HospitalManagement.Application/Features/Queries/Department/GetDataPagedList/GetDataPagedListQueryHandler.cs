using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Application.Features.Queries.Department.GetDataPagedList
{
    public class GetDataPagedListQueryHandler : IRequestHandler<GetDataPagedListQueryRequest, OptResult<PaginatedList<Domain.Entities.Management.Department>>>
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
        public async Task<OptResult<PaginatedList<Domain.Entities.Management.Department>>> Handle(GetDataPagedListQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _departmentSpecifications.GetDataPagedListPredicate(request);

            if (string.IsNullOrEmpty(request.OrderBy))
                request.OrderBy = "DepartmentName ASC";

            //var pagedDepartments = await _departmentReadRepository.GetDataPagedAsync(predicate, "", request.PageIndex, request.Take, request.OrderBy);

            //var responsePagedDataList = _mapper.Map<PaginatedList<GetDataPagedListQueryResponse>>(pagedDepartments.Data);
            //var paginatedList = await responsePagedDataList.AsQueryable().CreateAsync(request.PageIndex, request.Take);
            // return await OptResult<PaginatedList<GetDataPagedListQueryResponse>>.SuccessAsync(responsePagedDataList, Messages.Successfull);

            var pagedDepartments = await _departmentReadRepository.GetDataPagedAsync(predicate, "", request.PageIndex, request.Take, request.OrderBy);

            var responsePagedDataList = _mapper.Map<List<Domain.Entities.Management.Department>>(pagedDepartments.Data);

            var totalRecords = await _departmentReadRepository.CountAsync(predicate);
            var totalPages = (int)Math.Ceiling(totalRecords / (double)request.Take);
            var pagination = new Pagination
            {
                PageIndex = request.PageIndex,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                PageSize = request.Take,
                HasPreviousPage = request.PageIndex > 1,
                HasNextPage = request.PageIndex < totalPages
            };

            var paginatedList = new PaginatedList<Domain.Entities.Management.Department>
            {
                Data = responsePagedDataList,
                pagination = pagination
            };

            return await OptResult<PaginatedList<Domain.Entities.Management.Department>>.SuccessAsync(paginatedList, Messages.Successfull);
        }

    }
}
