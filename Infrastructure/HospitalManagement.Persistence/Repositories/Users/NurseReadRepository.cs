using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class NurseReadRepository : ReadRepository<Nurse>, INurseReadRepository
    {
        public NurseReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
