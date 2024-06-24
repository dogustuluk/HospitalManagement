using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class AppointmentReadRepository : ReadRepository<Domain.Entities.Appointment.Appointment>, IAppointmentReadRepository
    {
        public AppointmentReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
