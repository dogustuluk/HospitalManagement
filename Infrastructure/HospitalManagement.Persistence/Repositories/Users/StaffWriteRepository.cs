using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class StaffWriteRepository : WriteRepository<Staff>, IStaffWriteRepository
    {
        public StaffWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
