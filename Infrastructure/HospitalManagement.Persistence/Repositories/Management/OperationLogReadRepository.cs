using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class OperationLogReadRepository : ReadRepository<OperationLog>, IOperationLogReadRepository
    {
        public OperationLogReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
