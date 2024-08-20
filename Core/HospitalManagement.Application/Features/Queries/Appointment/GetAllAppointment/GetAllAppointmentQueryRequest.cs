namespace HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment
{
    public class GetAllAppointmentQueryRequest : IRequest<OptResult<List<GetAllAppointmentQueryResponse>>>
    {
        public string? SearchText { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }
        public string? OrderBy { get; set; } = "Id ASC";
        public int Discriminator { get; set; }

        public ExaminationAppointmentQuery_Dto? ExaminationAppointment { get; set; }
        public VisitorAppointmentQuery_Dto? VisitorAppointment { get; set; }
    }

    public class ExaminationAppointmentQuery_Dto
    {
        public int? HospitalId { get; set; }
        public int? ClinicId { get; set; }
        public string? ExaminationPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class VisitorAppointmentQuery_Dto
    {
        public int? PatientId { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }

}