namespace HospitalManagement.Application.Common.DTOs.Appointment
{
    public class GetAllPagedAppointment_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
    public class CreateAppointment_Dto
    {
        public Guid CreatedUser { get; set; }
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }
        public int UserType { get; set; }
        public int? PatientId { get; set; }
        public int? RoomId { get; set; }
        public string? Desc { get; set; }
        public int? HospitalId { get; set; }
        public int? ClinicId { get; set; }
        public string? ExaminationPlace { get; set; }
        public string? EMail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
    public class CreateVisitorAppointment_Dto
    {
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }
        public int? PatientId { get; set; }
        public int? RoomId { get; set; }
        public string? Desc { get; set; }
    }

    public class CreateExaminationAppointment_Dto
    {
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }
        public int? HospitalId { get; set; }
        public int? ClinicId { get; set; }
        public string? ExaminationPlace { get; set; }
        public string? EMail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
