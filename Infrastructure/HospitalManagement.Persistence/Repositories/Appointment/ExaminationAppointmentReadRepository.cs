using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Domain.Entities.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class ExaminationAppointmentReadRepository : ReadRepository<ExaminationAppointment>, IExaminationAppointmentReadRepository
    {
        public ExaminationAppointmentReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
