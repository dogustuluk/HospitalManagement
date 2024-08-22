namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine
{
    public class GetAllPagedMedicineQueryResponse
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Manufacturer { get; set; }
        public double Price { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public int MedicineDetailId { get; set; }
    }
}