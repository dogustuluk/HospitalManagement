using HospitalManagement.Application.Repositories;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class AnnouncementReadRepository : ReadRepository<Announcement>, IAnnouncementReadRepository
    {
        public AnnouncementReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
