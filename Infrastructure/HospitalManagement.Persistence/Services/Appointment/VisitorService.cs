using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Appointment
{
    [Service(ServiceLifetime.Scoped)]
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorAppointmentReadRepository _readRepository;
        private readonly IVisitorAppointmentWriteRepository _writeRepository;

        public VisitorService(IVisitorAppointmentReadRepository readRepository, IVisitorAppointmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
