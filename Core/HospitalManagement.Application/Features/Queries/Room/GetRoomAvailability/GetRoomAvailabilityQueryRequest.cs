namespace HospitalManagement.Application.Features.Queries.Room.GetRoomAvailability
{
    public class GetRoomAvailabilityQueryRequest : IRequest<OptResult<GetRoomAvailabilityQueryResponse>>
    {
        public int RoomId { get; set; }
    }
}