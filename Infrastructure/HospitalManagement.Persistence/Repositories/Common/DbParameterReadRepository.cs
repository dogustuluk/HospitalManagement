using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class DbParameterReadRepository : ReadRepository<DbParameter>, IDbParameterReadRepository
    {
        public DbParameterReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
