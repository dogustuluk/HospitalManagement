using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Common.DTOs._0RequestResponse;

namespace HospitalManagement.Application.Features.Queries.User.GetValueUser
{
    public class GetValueUserHandler : IRequestHandler<GetValueXQueryRequest, OptResult<GetValueXQueryResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetValueUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueXQueryResponse>> Handle(GetValueXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _userService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueXQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueXQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueXQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
