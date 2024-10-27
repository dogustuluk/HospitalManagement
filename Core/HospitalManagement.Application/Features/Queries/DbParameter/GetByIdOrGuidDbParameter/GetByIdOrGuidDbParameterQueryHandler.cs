
namespace HospitalManagement.Application.Features.Queries.DbParameter.GetByIdOrGuidDbParameter;
public class GetByIdOrGuidDbParameterQueryHandler : IRequestHandler<GetByIdOrGuidDbParameterQueryRequest, OptResult<GetByIdOrGuidDbParameterQueryResponse>>
{
    private readonly IDbParameterService _dbParameterService;
    private readonly IMapper _mapper;

    public GetByIdOrGuidDbParameterQueryHandler(IDbParameterService dbParameterService, IMapper mapper)
    {
        _dbParameterService = dbParameterService;
        _mapper = mapper;
    }

    public Task<OptResult<GetByIdOrGuidDbParameterQueryResponse>> Handle(GetByIdOrGuidDbParameterQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
