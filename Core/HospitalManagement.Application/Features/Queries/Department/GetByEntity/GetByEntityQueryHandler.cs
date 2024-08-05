namespace HospitalManagement.Application.Features.Queries.Department.GetByEntity
{
    public class GetByEntityQueryHandler : IRequestHandler<GetByEntityQueryRequest, OptResult<GetByEntityQueryResponse>>
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IMapper _mapper;

        public GetByEntityQueryHandler(IDepartmentReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByEntityQueryResponse>> Handle(GetByEntityQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetByEntityAsync(request.Value, request.FieldName);
            var mappedData = _mapper.Map<GetByEntityQueryResponse>(data);
            var response = new GetByEntityQueryResponse
            {
                Properties = data.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(data))
            };
            return OptResult<GetByEntityQueryResponse>.Success(response, Messages.Successfull);
        }
    }
}
