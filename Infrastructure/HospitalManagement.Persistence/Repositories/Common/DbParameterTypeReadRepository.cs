using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class DbParameterTypeReadRepository : ReadRepository<DbParameterType>, IDbParameterTypeReadRepository
    {
        public DbParameterTypeReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
