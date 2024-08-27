namespace HospitalManagement.Domain.Entities.Common
{
    public class Bed : BaseEntity
    {
        public int RoomId { get; set; }
        public int RoomBedNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string? PatientId { get; set; }
        //yatak tipi de ekle
        public Room? Room { get; set; }
    }
}