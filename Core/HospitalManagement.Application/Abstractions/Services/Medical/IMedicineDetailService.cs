using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Abstractions.Services.Medical
{
    public interface IMedicineDetailService
    {
        Task<OptResult<MedicineDetail>> GetMedicineDetail(int id);
        Task<OptResult<MedicineDetail>> UpdateMedicineDetail(Update_MedicineDetail_Dto model);
        Task<OptResult<MedicineDetail>> AddMedicineDetail(Add_MedicineDetail_Dto model);
        Task<OptResult<MedicineDetail>> DeleteMedicineDetail(int id, bool? isHardDelete = false);

    }
}
