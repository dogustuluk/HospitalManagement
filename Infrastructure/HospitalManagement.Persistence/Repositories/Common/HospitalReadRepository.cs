using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class HospitalReadRepository : ReadRepository<Hospital>, IHospitalReadRepository
    {
        public HospitalReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
