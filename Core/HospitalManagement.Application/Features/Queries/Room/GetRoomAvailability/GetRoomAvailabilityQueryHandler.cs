using HospitalManagement.Application.Constants;

namespace HospitalManagement.Application.Features.Queries.Room.GetRoomAvailability
{
    public class GetRoomAvailabilityQueryHandler : IRequestHandler<GetRoomAvailabilityQueryRequest, OptResult<GetRoomAvailabilityQueryResponse>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public GetRoomAvailabilityQueryHandler(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetRoomAvailabilityQueryResponse>> Handle(GetRoomAvailabilityQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var isAvailableRoom = await _roomService.GetRoomAvailabilityAsync(request.RoomId);
                
                if (isAvailableRoom.Data.Item2 == false)
                    return await OptResult<GetRoomAvailabilityQueryResponse>.FailureAsync("Oda müsait değildir.");

                var mappedAvailableRoom = _mapper.Map<GetRoomAvailabilityQueryResponse>(isAvailableRoom.Data.Item1);
                
                return await OptResult<GetRoomAvailabilityQueryResponse>.SuccessAsync(mappedAvailableRoom, "Oda Müsait.");
            });
        }
    }
}
