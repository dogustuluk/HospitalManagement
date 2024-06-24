using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class RoomService : IRoomService
    {
        private readonly IRoomReadRepository _readRepository;
        private readonly IRoomWriteRepository _writeRepository;

        public RoomService(IRoomReadRepository readRepository, IRoomWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
