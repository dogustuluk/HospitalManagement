using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class StatusWriteRepository : WriteRepository<Status>, IStatusWriteRepository
    {
        public StatusWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
