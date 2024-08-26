namespace HospitalManagement.Application.Features.Commands.Room.CreateRoom
{
    public class CreateRoomCommandResponse
    {
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; }
        public List<string> PatientIds { get; set; }
    }
}