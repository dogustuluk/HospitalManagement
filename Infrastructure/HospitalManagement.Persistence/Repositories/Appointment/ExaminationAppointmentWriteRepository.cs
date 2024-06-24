using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Domain.Entities.Appointment;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Appointment
{
    public class ExaminationAppointmentWriteRepository : WriteRepository<ExaminationAppointment>, IExaminationAppointmentWriteRepository
    {
        public ExaminationAppointmentWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
