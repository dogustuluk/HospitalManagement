using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class VisitorReadRepository : ReadRepository<Visitor>, IVisitorReadRepository 
    {
        public VisitorReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
