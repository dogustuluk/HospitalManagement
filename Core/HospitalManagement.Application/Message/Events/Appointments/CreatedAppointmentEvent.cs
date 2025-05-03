namespace HospitalManagement.Application.Message.Events.Appointments;
public class CreatedAppointmentEvent
{
    public Guid AppointmentId { get; set; }
    public Guid CreatedUser { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
}
