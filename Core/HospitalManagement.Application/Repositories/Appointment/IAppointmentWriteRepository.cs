using HospitalManagement.Domain.Entities.Appointment;

namespace HospitalManagement.Application.Repositories.Appointment
{
    public interface IAppointmentWriteRepository : IWriteRepository<Domain.Entities.Appointment.Appointment>
    {
    }
}
