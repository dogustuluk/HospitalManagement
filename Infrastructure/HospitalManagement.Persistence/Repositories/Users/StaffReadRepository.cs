using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class StaffReadRepository : ReadRepository<Staff>, IStaffReadRepository
    {
        public StaffReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
