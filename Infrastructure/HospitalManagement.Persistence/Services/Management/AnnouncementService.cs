using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementReadRepository _readRepository;
        private readonly IAnnouncementWriteRepository _writeRepository;

        public AnnouncementService(IAnnouncementReadRepository readRepository, IAnnouncementWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
