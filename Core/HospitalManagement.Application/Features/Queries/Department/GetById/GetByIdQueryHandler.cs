using HospitalManagement.Application.Repositories.Management;

namespace HospitalManagement.Application.Features.Queries.Department.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryRequest, OptResult<GetByIdQueryResponse>>
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IDepartmentReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByIdQueryResponse>> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetByIdAsync(request.Id);
            var mappedData = _mapper.Map<GetByIdQueryResponse>(data);
            return await OptResult<GetByIdQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
        }
    }
}