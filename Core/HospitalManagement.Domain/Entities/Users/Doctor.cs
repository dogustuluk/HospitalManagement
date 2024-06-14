using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Domain.Entities.Identity;

namespace HospitalManagement.Domain.Entities.Users
{
    public class Doctor : BaseEntity
    {
        public string AppUserId { get; set; }
        public int SpecializationId { get; set; } //ItemType'dan al
        public int DepartmentId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime DoctorStartDate { get; set; }
        public DateTime? DoctorLeftDate { get; set; }
        public string? Certifications { get; set; }
        public string? Languages { get; set; }
        public DateTime? ConsultationHours { get; set; }
        public List<AnyParam>? Params { get; set; } //ProfessionalMemberships,Publications,ResearchInterests,etc.

        public string? Notes { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
