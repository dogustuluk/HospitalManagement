namespace HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital
{
    public class UpdateHospitalCommandResponse
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
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}