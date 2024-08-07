using HospitalManagement.Application.Common.DTOs.Appointment;

namespace HospitalManagement.Application.Abstractions.Services.Appointment
{
    public interface IAppointmentService
    {
        Task<OptResult<CreateAppointment_Dto>> CreateAppointmentAsync(CreateAppointment_Dto Model);
    }
}
