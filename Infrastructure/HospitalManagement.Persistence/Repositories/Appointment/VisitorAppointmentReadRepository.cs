using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Domain.Entities.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class VisitorAppointmentReadRepository : ReadRepository<VisitorAppointment>, IVisitorAppointmentReadRepository
    {
        public VisitorAppointmentReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
