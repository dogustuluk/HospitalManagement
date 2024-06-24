using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class StatusReadRepository : ReadRepository<Status>, IStatusReadRepository
    {
        public StatusReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
