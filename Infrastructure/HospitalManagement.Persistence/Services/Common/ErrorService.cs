using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class ErrorService : IErrorService
    {
        private readonly IErrorReadRepository _readRepository;
        private readonly IErrorWriteRepository _writeRepository;

        public ErrorService(IErrorReadRepository readRepository, IErrorWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
