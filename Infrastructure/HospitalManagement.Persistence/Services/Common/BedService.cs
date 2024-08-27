using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class BedService : IBedService
    {
        private readonly IBedReadRepository _readRepository;
        private readonly IBedWriteRepository _writeRepository;

        public BedService(IBedReadRepository readRepository, IBedWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}