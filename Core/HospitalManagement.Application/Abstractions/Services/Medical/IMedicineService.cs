using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Abstractions.Services.Medical
{
    public interface IMedicineService
    {
        Task<OptResult<Medicine>> CreateMedicineAsync(Create_Medicine_Dto model);
        Task<OptResult<Medicine>> UpdateMedicineAsync(Update_Medicine_Dto model);
        Task<List<Medicine>> GetAllMedicine(Expression<Func<Medicine, bool>>? predicate, string? include);
        Task<List<DataList1>> GetDataListAsync();
        Task<OptResult<Medicine>> GetByIdOrGuid(object criteria);
        Task<OptResult<PaginatedList<Medicine>>> GetAllPagedListAsync(GetAllPaged_Medicine_Index_Dto model);
        Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType);
    }
}
