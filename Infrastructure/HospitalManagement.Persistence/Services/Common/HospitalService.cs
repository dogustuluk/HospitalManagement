using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalReadRepository _readRepository;
        private readonly IHospitalWriteRepository _writeRepository;

        public HospitalService(IHospitalReadRepository readRepository, IHospitalWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
