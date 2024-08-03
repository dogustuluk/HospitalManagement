namespace HospitalManagement.Application.Features.Queries.Department.GetDataList
{
    public class GetDataListQueryHandler : IRequestHandler<GetDataListQueryRequest, OptResult<List<GetDataListQueryResponse>>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public GetDataListQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListQueryResponse>>> Handle(GetDataListQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var departments = await _departmentService.GetDataListAsync();

                if (departments == null)
                {
                    return OptResult<List<GetDataListQueryResponse>>.Failure("No departments found.");
                }

                var response = _mapper.Map<List<GetDataListQueryResponse>>(departments);
                return OptResult<List<GetDataListQueryResponse>>.Success(response);
            });
        }
    }
}
