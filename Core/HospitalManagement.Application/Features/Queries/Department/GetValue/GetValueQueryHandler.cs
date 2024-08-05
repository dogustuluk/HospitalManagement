namespace HospitalManagement.Application.Features.Queries.Department.GetValue
{
    public class GetValueQueryHandler : IRequestHandler<GetValueQueryRequest, OptResult<GetValueQueryResponse>>
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetValueQueryHandler(IDepartmentReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueQueryResponse>> Handle(GetValueQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetValueAsync("Departments", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
            var mappedData = _mapper.Map<GetValueQueryResponse>(data);
            return await OptResult<GetValueQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
        }
    }
}
