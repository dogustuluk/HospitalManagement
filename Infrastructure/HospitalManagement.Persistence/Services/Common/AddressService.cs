using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Application.Repositories.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class AddressService : IAddressService
    {
        private readonly IAddressReadRepository _readRepository;
        private readonly IAddressWriteRepository _writeRepository;

        public AddressService(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
