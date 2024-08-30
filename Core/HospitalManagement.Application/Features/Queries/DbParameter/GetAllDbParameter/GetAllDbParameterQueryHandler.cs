namespace HospitalManagement.Application.Features.Queries.DbParameter.GetAllDbParameter
{
    public class GetAllDbParameterQueryHandler : IRequestHandler<GetAllDbParameterQueryRequest, OptResult<List<GetAllDbParameterQueryResponse>>>
    {
        private readonly IDbParameterService _dbParameterService;
        private readonly IMapper _mapper;
        private readonly DbParameterSpecifications _dbParameterSpecifications;
        public GetAllDbParameterQueryHandler(IDbParameterService dbParameterService, IMapper mapper, DbParameterSpecifications dbParameterSpecifications)
        {
            _dbParameterService = dbParameterService;
            _mapper = mapper;
            _dbParameterSpecifications = dbParameterSpecifications;
        }

        public async Task<OptResult<List<GetAllDbParameterQueryResponse>>> Handle(GetAllDbParameterQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var predicate = _dbParameterSpecifications.GetAllPredicate(request);
                var datas = await _dbParameterService.GetAllDbParameterAsync(predicate, "");

                if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "DbParameterName1 ASC";

                var dataList = _mapper.Map<List<GetAllDbParameterQueryResponse>>(datas);

                return await OptResult<List<GetAllDbParameterQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
            });
        }
    }
}
