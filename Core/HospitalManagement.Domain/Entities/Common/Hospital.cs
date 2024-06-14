﻿namespace HospitalManagement.Domain.Entities.Common
{
    public class Hospital : BaseEntity
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
        public List<Address>? Address { get; set; } = new List<Address>();
        public string? MedicalSpecialtiesJson { get; set; } //uzmanlık alanları
        public string? FacilitiesJson { get; set; } //hastanedeki tıbbi ve idari olanaklar (laboratuvarlar, ameliyathaneler, eczaneler)
        public string? Longitude { get; set; }
        public string? Latitude { get; set;}
        public string? OperatingHours { get; set; }
        public string? VisitHours { get; set; }
    }
}
