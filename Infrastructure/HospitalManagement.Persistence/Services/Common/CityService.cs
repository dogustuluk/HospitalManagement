using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class CityService : ICityService
    {
        private readonly ICityReadRepository _readRepository;
        private readonly ICityWriteRepository _writeRepository;

        public CityService(ICityReadRepository readRepository, ICityWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
