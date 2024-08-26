using HospitalManagement.Application.Common.DTOs._0RequestResponse;

namespace HospitalManagement.Application.Features.Queries.Room.GetValueRoom
{
    //duzenle
    public class GetValueRoomQueryHandler : IRequestHandler<GetValueXQueryRequest, OptResult<GetValueXQueryResponse>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public async Task<OptResult<GetValueXQueryResponse>> Handle(GetValueXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _roomService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueXQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueXQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueXQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
