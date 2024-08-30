using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetAllPagedDbParameterType;

namespace HospitalManagement.Application.Features.Queries.DbParameter.GetAllPagedDbParameter
{
    public class GetAllPagedDbParameterQueryHandler : IRequestHandler<GetAllPagedDbParameterQueryRequest, OptResult<PaginatedList<GetAllPagedDbParameterQueryResponse>>>
    {
        private readonly IDbParameterService _dbParameterService;
        private readonly IMapper _mapper;

        public GetAllPagedDbParameterQueryHandler(IDbParameterService dbParameterService, IMapper mapper)
        {
            _dbParameterService = dbParameterService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedDbParameterQueryResponse>>> Handle(GetAllPagedDbParameterQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPaged_DBParameter_Index_Dto>(request);

                var result = await _dbParameterService.GetAllPagedDbParameterAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedDbParameterQueryResponse>>(result.Data);

                if (result == null) return await OptResult<PaginatedList<GetAllPagedDbParameterQueryResponse>>.FailureAsync(Messages.NullData);

                return await OptResult<PaginatedList<GetAllPagedDbParameterQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
