using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class NurseWriteRepository : WriteRepository<Nurse>, INurseWriteRepository
    {
        public NurseWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
