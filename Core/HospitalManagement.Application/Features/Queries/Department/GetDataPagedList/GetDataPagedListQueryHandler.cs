namespace HospitalManagement.Application.Features.Queries.Department.GetDataPagedList
{
    public class GetDataPagedListQueryHandler : IRequestHandler<GetDataPagedListQueryRequest, OptResult<PaginatedList<GetDataPagedListQueryResponse>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public GetDataPagedListQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetDataPagedListQueryResponse>>> Handle(GetDataPagedListQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPaged_Index_Dto>(request);

                var result = await _departmentService.GetDataPagedForDepartment(model);

                var response = _mapper.Map<PaginatedList<GetDataPagedListQueryResponse>>(result.Data);

                if (response != null) 
                    return await OptResult<PaginatedList<GetDataPagedListQueryResponse>>.SuccessAsync(response, Messages.Successfull);
                return await OptResult<PaginatedList<GetDataPagedListQueryResponse>>.FailureAsync(Messages.UnSuccessfull);
            });
        }
    }
}