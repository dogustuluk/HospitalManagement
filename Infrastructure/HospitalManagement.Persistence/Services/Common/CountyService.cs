using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class CountyService : ICountryService
    {
        private readonly ICountryReadRepository _readRepository;
        private readonly ICountryWriteRepository _writeRepository;

        public CountyService(ICountryReadRepository readRepository, ICountryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
