using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ReminderReadRepository : ReadRepository<Reminder>, IReminderReadRepository
    {
        public ReminderReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
