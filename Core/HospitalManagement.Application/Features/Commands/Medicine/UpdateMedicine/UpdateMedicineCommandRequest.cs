using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Features.Commands.Medicine.UpdateMedicine
{
    public class UpdateMedicineCommandRequest : IRequest<OptResult<UpdateMedicineCommandResponse>>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Manufacturer { get; set; }
        public string? Usage { get; set; }
        public double Price { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Stock { get; set; }
        public MedicineType MedicineType { get; set; }
        public int MedicineCategory { get; set; }
        public Update_MedicineDetail_Dto MedicineDetail { get; set; }
    }
}