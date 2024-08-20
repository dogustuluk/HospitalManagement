using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Common.DTOs.Management;
using app = HospitalManagement.Domain.Entities.Appointment;

namespace HospitalManagement.Application.Abstractions.Services.Appointment
{
    public interface IAppointmentService
    {
        Task<OptResult<CreateAppointment_Dto>> CreateAppointmentAsync(CreateAppointment_Dto Model);
        Task<List<app.Appointment>> GetAllAppointment(Expression<Func<Domain.Entities.Appointment.Appointment, bool>>? predicate, string? include);
        Task<OptResult<app.Appointment>> GetByIdOrGuid(object criteria);
        Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType);
        Task<List<DataList1>> GetDataListAsync();
        Task<OptResult<PaginatedList<app.Appointment>>> GetAllPagedListAsync(GetAllPagedAppointment_Index_Dto model);

    }
}
