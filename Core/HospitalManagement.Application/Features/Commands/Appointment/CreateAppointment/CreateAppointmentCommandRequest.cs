namespace HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment
{
    [CommandRequestMapping]
    public class CreateAppointmentCommandRequest : IRequest<OptResult<CreateAppointmentCommandResponse>>
    {
        public Guid CreatedUser { get; set; }
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }
        public int UserType { get; set; }

        // VisitorAppointment
        public int? PatientId { get; set; }
        public int? RoomId { get; set; }
        public string? Desc { get; set; }

        // ExaminationAppointment
        public int? HospitalId { get; set; }
        public int? ClinicId { get; set; }
        public string? ExaminationPlace { get; set; }
        public string? EMail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}