using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Domain.Entities.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class VisitorAppointmentWriteRepository : WriteRepository<VisitorAppointment>, IVisitorAppointmentWriteRepository
    {
        public VisitorAppointmentWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
