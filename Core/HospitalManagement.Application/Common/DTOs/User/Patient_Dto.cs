namespace HospitalManagement.Application.Common.DTOs.User
{
    public class Create_Patient_Dto
    {
        public int PatientType { get; set; }
        public int AppUserId { get; set; }
        public int DepartmentId { get; set; }
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string Diagnosis { get; set; }
        public List<int>? Doctors { get; set; }
        public List<int>? Medicines { get; set; }
        public int? TreatmentPlanId { get; set; }
        public string? Desc { get; set; }
    }

    public class GetAllPaged_Patient_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int PatientType { get; set; }
        public int DepartmentId { get; set; }
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}
