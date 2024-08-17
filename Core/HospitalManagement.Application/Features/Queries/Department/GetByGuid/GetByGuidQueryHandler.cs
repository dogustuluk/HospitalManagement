namespace HospitalManagement.Application.Features.Queries.Department.GetByGuid
{
    public class GetByGuidQueryHandler : IRequestHandler<GetByGuidQueryRequest, OptResult<GetByGuidQueryResponse>>
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IMapper _mapper;

        public GetByGuidQueryHandler(IDepartmentReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByGuidQueryResponse>> Handle(GetByGuidQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _readRepository.GetByGuidAsync(request.Guid);
                var mappedData = _mapper.Map<GetByGuidQueryResponse>(data);
                if (mappedData.Id > 0)
                    return await OptResult<GetByGuidQueryResponse>.SuccessAsync(mappedData);
                return await OptResult<GetByGuidQueryResponse>.FailureAsync(mappedData);
            });
        }
    }
}
