namespace HospitalManagement.Application.Abstractions.Services.Management
{
    public interface IServiceLogService
    {
        Task<OptResult<ServiceLog>> CreateLogAsync(Create_ServiceLog_Dto model);
    }
}
