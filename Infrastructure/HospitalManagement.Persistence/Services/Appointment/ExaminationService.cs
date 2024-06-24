using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Appointment
{
    [Service(ServiceLifetime.Scoped)]
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationAppointmentReadRepository _readRepository;
        private readonly IExaminationAppointmentWriteRepository _writeRepository;

        public ExaminationService(IExaminationAppointmentReadRepository readRepository, IExaminationAppointmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
