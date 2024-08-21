namespace HospitalManagement.Application.Abstractions.Services.Management
{
    public interface IDepartmentService
    {
        Task<OptResult<Create_Department_Dto>> CreateDepartment(Create_Department_Dto create_Department);
        Task<OptResult<Department>> UpdateDepartmentAsync(Update_Department_Dto model);
        Task<List<Department>> GetAllDepartment(Expression<Func<Department, bool>>? predicate, string? include);
        Task<OptResult<PaginatedList<Department>>> GetDataPagedForDepartment(GetAllPaged_Index_Dto model);
        Task<List<DataList1>> GetDataListAsync();
    }
}
