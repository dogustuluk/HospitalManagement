using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Appointment
{
    [Service(ServiceLifetime.Scoped)]
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository _readRepository;
        private readonly IAppointmentWriteRepository _writeRepository;

        public AppointmentService(IAppointmentReadRepository readRepository, IAppointmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
