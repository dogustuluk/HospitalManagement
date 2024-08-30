using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class DbParameterTypeWriteRepository : WriteRepository<DbParameterType>, IDbParameterTypeWriteRepository
    {
        public DbParameterTypeWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
