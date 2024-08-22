using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class DbParameterTypeService : IDbParameterTypeService
    {
        private readonly IDbParameterTypeReadRepository _readRepository;
        private readonly IDbParameterTypeWriteRepository _writeRepository;

        public DbParameterTypeService(IDbParameterTypeReadRepository readRepository, IDbParameterTypeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
