namespace HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital
{
    public class GetByIdOrGuidHospitalQueryResponse
    {
        public string HospitalName { get; set; }
        public int ItemType { get; set; }
        public string? HospitalCode { get; set; }
        public string HospitalOwner { get; set; }
        public DateTime? HospitalEstablishedDate { get; set; }
        public bool EmergencyService { get; set; }
        public int TotalRooms { get; set; }
        public int TotalBeds { get; set; }
        public int AvailableBeds { get; set; }
        public int TotalFloors { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalPersonels { get; set; }
        public string? HospitalDetailJson { get; set; }
        public string? MedicalSpecialtiesJson { get; set; }
        public string? FacilitiesJson { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? OperatingHours { get; set; }
        public string? VisitHours { get; set; }
    }
}