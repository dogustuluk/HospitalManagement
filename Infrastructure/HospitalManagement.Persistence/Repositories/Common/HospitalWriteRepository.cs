using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class HospitalWriteRepository : WriteRepository<Hospital>, IHospitalWriteRepository
    {
        public HospitalWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
