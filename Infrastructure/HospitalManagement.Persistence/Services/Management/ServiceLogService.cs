using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class ServiceLogService : IServiceLogService
    {
        private readonly IServiceLogReadRepository _readRepository;
        private readonly IServiceLogWriteRepository _writeRepository;

        public ServiceLogService(IServiceLogReadRepository readRepository, IServiceLogWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
