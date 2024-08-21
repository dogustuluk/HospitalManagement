using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Abstractions.Services.Medical
{
    public interface IMedicineService
    {
        Task<OptResult<Medicine>> CreateMedicineAsync(Create_Medicine_Dto model);
    }
}
