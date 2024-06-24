using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class VisitorWriteRepository : WriteRepository<Visitor>, IVisitorWriteRepository
    {
        public VisitorWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
