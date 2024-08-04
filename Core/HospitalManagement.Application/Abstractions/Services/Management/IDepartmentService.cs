namespace HospitalManagement.Application.Abstractions.Services.Management
{
    public interface IDepartmentService
    {
        Task<OptResult<Create_Department_Dto>> CreateDepartment(Create_Department_Dto create_Department);
        Task<List<Department>> GetAllDepartment(Expression<Func<Department, bool>>? predicate, string? include);
        Task<List<DataList1>> GetDataListAsync();
        //Task<PaginatedList<Department>> GetDepartmentPagedAsync
    }
}
