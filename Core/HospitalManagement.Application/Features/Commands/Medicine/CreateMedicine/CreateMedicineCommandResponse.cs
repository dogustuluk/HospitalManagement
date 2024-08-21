using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Features.Commands.Medicine.CreateMedicine
{
    public class CreateMedicineCommandResponse
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

        public Create_MedicineDetail_Dto MedicineDetail { get; set; }
    }
}