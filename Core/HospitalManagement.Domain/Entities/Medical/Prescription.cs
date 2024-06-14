using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Medical
{
    public class Prescription : BaseEntity
    {
        public Prescription()
        {
            Medicines = new List<Medicine>();
        }

        //public int TreatmentPlanId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string? Instructions { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsFilled { get; set; }
        public string? Notes { get; set; }

        public virtual TreatmentPlan TreatmentPlan { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
