namespace HospitalManagement.Application.Features.Queries.Room.GetByIdOrGuidRoom
{
    public class GetByIdOrGuidRoomQueryResponse
    {
        public int id { get; set; }
        public Guid Guid { get; set; }
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; }
        public List<string> PatientIds { get; set; }
    }
}