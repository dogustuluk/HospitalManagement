using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Abstractions.Services.Common
{
    public interface IHospitalService
    {
        Task<OptResult<Hospital>> CreateHospitalAsync(CreateHospital_Dto model);
        Task<OptResult<Hospital>> UpdateHospitalAsync(UpdateHospital_Dto model);
        Task<List<Hospital>> GetAllHospital(Expression<Func<Hospital, bool>>? predicate, string? include);
        Task<List<DataList1>> GetDataListAsync();
        Task<OptResult<Hospital>> GetByIdOrGuid(object criteria);
        Task<OptResult<PaginatedList<Hospital>>> GetAllPagedListAsync(GetAllPagedHospital_Index_Dto model);
    }
}
