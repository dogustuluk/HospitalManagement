namespace HospitalManagement.Application.Common.DTOs.Common
{
    public class CreateHospital_Dto
    {
        public string HospitalName { get; set; }
        public int ItemType { get; set; }
        public string? HospitalCode { get; set; }
        public string? HospitalOwner { get; set; }
        public DateTime? HospitalEstablishedDate { get; set; }
        public bool EmergencyService { get; set; }
        public string? HospitalDetailJson { get; set; }
        //public List<Address>? Address { get; set; } = new List<Address>();
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? OperatingHours { get; set; }
        public string? VisitHours { get; set; }
    }
    public class UpdateHospital_Dto
    {
        public Guid Guid { get; set; }
        public string HospitalName { get; set; }
        public int ItemType { get; set; }
        public string? HospitalCode { get; set; }
        public string HospitalOwner { get; set; }
        public DateTime? HospitalEstablishedDate { get; set; }
        public bool EmergencyService { get; set; }
        public string? HospitalDetailJson { get; set; }
        //public List<Address>? Address { get; set; } = new List<Address>();
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? OperatingHours { get; set; }
        public string? VisitHours { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class GetAllPagedHospital_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}
