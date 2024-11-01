﻿using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Domain.Entities.Medical;

namespace HospitalManagement.Domain.Entities.Users
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            Doctors = new List<int>();
        }
        public int PatientType { get; set; } //yatılı,transfer,normal
        public int AppUserId { get; set; }
        public int DepartmentId { get; set; }
        public int? RoomId { get; set; }
        public int BedId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string Diagnosis { get; set; }
        public List<int>? Doctors { get; set; }
        public List<int>? Medicines { get; set; }
        public int? TreatmentPlanId { get; set; }
        public string? Desc { get; set; }
        

        public virtual AppUser AppUser { get; set; }
        public virtual TreatmentPlan? TreatmentPlan { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Medicine? Medicine { get; set; }
    }
}
//ilaclar,tedavi plani,receteler, faturalari, hasta geri donusleri(sikayet,oneri,vs), randevu gecmisi, hastane kayitlari, diyet plani,randevulari,
//tedavi planlari icerisinden recetelere ve recetelerden de hastanin kullandigi ilaclara erismek daha yonetilir olabilir.