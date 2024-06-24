using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class AnyParamWriteRepository : WriteRepository<AnyParam>, IAnyParamWriteRepository
    {
        public AnyParamWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
