using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ReminderWriteRepository : WriteRepository<Reminder>, IReminderWriteRepository
    {
        public ReminderWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
