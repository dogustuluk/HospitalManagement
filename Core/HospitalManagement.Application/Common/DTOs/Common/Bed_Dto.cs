namespace HospitalManagement.Application.Common.DTOs.Common
{
    public class BedResponse
    {
        public int RoomBedNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string PatientId { get; set; }
    }
}
