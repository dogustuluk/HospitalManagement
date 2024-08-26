namespace HospitalManagement.Application.Features.Queries.Room.GetAllPagedRoom
{
    public class GetAllPagedRoomQueryResponse
    {
        public Guid Guid { get; set; }
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; }
    }
}