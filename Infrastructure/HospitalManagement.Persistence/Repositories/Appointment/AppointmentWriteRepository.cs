using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class AppointmentWriteRepository : WriteRepository<Domain.Entities.Appointment.Appointment>, IAppointmentWriteRepository
    {
        public AppointmentWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
