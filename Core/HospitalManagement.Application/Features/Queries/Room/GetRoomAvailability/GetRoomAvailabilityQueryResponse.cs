namespace HospitalManagement.Application.Features.Queries.Room.GetRoomAvailability
{
    public class GetRoomAvailabilityQueryResponse
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public List<int> RoomBedNumber { get; set; }
    }
}