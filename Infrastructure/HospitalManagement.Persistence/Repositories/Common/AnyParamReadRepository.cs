using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class AnyParamReadRepository : ReadRepository<AnyParam>, IAnyParamReadRepository
    {
        public AnyParamReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
