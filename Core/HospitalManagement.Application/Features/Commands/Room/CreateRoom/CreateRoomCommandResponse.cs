using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Features.Commands.Room.CreateRoom
{
    public class CreateRoomCommandResponse
    {
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; }
        public int TotalBedNumber { get; set; }
        public List<BedResponse>? Beds { get; set; }

    }
}