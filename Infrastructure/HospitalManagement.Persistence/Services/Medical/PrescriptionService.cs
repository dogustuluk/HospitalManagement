using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionReadRepository _readRepository;
        private readonly IPrescriptionWriteRepository _writeRepository;

        public PrescriptionService(IPrescriptionReadRepository readRepository, IPrescriptionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
