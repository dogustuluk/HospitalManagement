using HospitalManagement.Application.Common.DTOs._0RequestResponse;

namespace HospitalManagement.Application.Features.Queries.DbParameterType.GetDataListDbParameterType
{
    public class GetDataListDbParameterTypeQueryHandler : IRequestHandler<GetDataListXQueryRequest, OptResult<List<GetDataListXQueryResponse>>>
    {
        private readonly IDbParameterTypeService _dbParameterTypeService;
        private readonly IMapper _mapper;

        public GetDataListDbParameterTypeQueryHandler(IDbParameterTypeService dbParameterTypeService, IMapper mapper)
        {
            _dbParameterTypeService = dbParameterTypeService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListXQueryResponse>>> Handle(GetDataListXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myDatas = await _dbParameterTypeService.GetDataListAsync();

                if (myDatas == null) return await OptResult<List<GetDataListXQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListXQueryResponse>>(myDatas);

                return await OptResult<List<GetDataListXQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}
