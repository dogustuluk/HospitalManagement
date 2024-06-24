using HospitalManagement.Application.Repositories;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class AnnouncementWriteRepository : WriteRepository<Announcement>, IAnnouncementWriteRepository
    {
        public AnnouncementWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
