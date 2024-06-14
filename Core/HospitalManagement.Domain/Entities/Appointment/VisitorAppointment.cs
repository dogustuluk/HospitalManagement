namespace HospitalManagement.Domain.Entities.Appointment
{
    public class VisitorAppointment : Appointment
    {
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public string? Desc { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
