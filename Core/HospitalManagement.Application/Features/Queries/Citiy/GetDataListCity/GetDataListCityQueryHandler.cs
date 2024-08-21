namespace HospitalManagement.Application.Features.Queries.Citiy.GetDataListCity
{
    public class GetDataListCityQueryHandler : IRequestHandler<GetDataListCityQueryRequest, OptResult<List<GetDataListCityQueryResponse>>>
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public GetDataListCityQueryHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListCityQueryResponse>>> Handle(GetDataListCityQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myCities = await _cityService.GetDataListAsync();

                if (myCities == null) return await OptResult<List<GetDataListCityQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListCityQueryResponse>>(myCities);

                return await OptResult<List<GetDataListCityQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}
