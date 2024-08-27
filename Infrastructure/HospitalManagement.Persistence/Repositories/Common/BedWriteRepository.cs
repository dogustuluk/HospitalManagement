using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class BedWriteRepository : WriteRepository<Bed>, IBedWriteRepository
    {
        public BedWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
