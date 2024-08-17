using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Appointment
{
    public class Appointment : BaseEntity
    {
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }        
        public int Status { get; set; }
    }
}
