using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Features.Queries.Medicine.GetDataListMedicine;

namespace HospitalManagement.Application.Features.Queries.User.GetDataListUser
{
    public class GetDataListMedicineQueryHandler : IRequestHandler<GetDataListXQueryRequest, OptResult<List<GetDataListXQueryResponse>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetDataListMedicineQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListXQueryResponse>>> Handle(GetDataListXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myData = await _userService.GetDataListAsync(request.Filter);

                if (myData == null) return await OptResult<List<GetDataListXQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListXQueryResponse>>(myData);

                return await OptResult<List<GetDataListXQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}
