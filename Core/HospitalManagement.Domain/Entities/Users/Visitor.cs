using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Users
{
    public class Visitor : BaseEntity
    { //visitorAppointment Status=1 olanlari buraya ekle
        public string NameSurname { get; set; }
        public Guid PatientGuid { get; set; }
        public string VisitorCode { get; set; }
        public DateTime VisitDate { get; set; }
        public string? VisitDesc { get; set; }

    }
}
