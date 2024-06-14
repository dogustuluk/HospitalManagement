using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Medical
{
    public class Medicine : BaseEntity
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

        public virtual MedicineDetail? MedicineDetail { get; set; }
    }
}
