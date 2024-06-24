using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class AnyParamService : IAnyParamService
    {
        private readonly IAnyParamReadRepository _readRepository;
        private readonly IAnyParamWriteRepository _writeRepository;

        public AnyParamService(IAnyParamReadRepository readRepository, IAnyParamWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
