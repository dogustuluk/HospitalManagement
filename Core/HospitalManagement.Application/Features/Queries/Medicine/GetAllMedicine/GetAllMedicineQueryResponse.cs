namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine
{
    public class GetAllMedicineQueryResponse
    {
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Manufacturer { get; set; }
        public string? Usage { get; set; }
        public double Price { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Stock { get; set; }

        public int MedicineDetailId { get; set; }

        public MedicineDetail? MedicineDetail { get; set; }
    }
}