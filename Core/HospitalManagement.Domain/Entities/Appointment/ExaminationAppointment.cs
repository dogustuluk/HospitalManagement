namespace HospitalManagement.Domain.Entities.Appointment
{
    public class ExaminationAppointment : Appointment
    {
        public int HospitalId { get; set; }
        public int ClinicId { get; set; } //DbParameter'dan alinacak
        public string ExaminationPlace { get; set; } //muayene yeri
        public string EMail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
