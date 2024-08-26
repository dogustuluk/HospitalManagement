using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;

namespace HospitalManagement.Application.Features.Queries.Room.GetByIdOrGuidRoom
{
    public class GetByIdOrGuidRoomQueryHandler : IRequestHandler<GetByIdOrGuidRoomQueryRequest, OptResult<GetByIdOrGuidRoomQueryResponse>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public GetByIdOrGuidRoomQueryHandler(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByIdOrGuidRoomQueryResponse>> Handle(GetByIdOrGuidRoomQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                object value = null;
                if (request.Id != null) value = request.Id;
                if (request.guid != null) value = request.guid;
                var data = await _roomService.GetByIdOrGuidAsync(value);

                var mappedData = _mapper.Map<GetByIdOrGuidRoomQueryResponse>(data.Data);
                if (mappedData == null) return await OptResult<GetByIdOrGuidRoomQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetByIdOrGuidRoomQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
