using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class BedReadRepository : ReadRepository<Bed>, IBedReadRepository
    {
        public BedReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
