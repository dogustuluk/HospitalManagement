using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Medical
{
    public class TreatmentPlan : BaseEntity
    {
        public TreatmentPlan()
        {
            Doctors = new List<int>();
            Prescriptions = new List<Prescription>();
        }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public List<int> Doctors { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }
}
