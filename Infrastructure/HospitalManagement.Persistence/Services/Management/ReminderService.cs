using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class ReminderService : IReminderService
    {
        private readonly IReminderReadRepository _readRepository;
        private readonly IReminderWriteRepository _writeRepository;

        public ReminderService(IReminderReadRepository readRepository, IReminderWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
