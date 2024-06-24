using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class OperationLogWriteRepository : WriteRepository<OperationLog>, IOperationLogWriteRepository
    {
        public OperationLogWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
