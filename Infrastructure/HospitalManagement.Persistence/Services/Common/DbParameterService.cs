using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class DbParameterService : IDbParameterService
    {
        private readonly IDbParameterReadRepository _readRepository;
        private readonly IDbParameterWriteRepository _writeRepository;

        public DbParameterService(IDbParameterReadRepository readRepository, IDbParameterWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
