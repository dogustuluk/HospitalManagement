namespace HospitalManagement.Application.Abstractions.Services.Common
{
    public interface ICityService
    {
        Task<List<DataList1>> GetDataListAsync();
    }
}
