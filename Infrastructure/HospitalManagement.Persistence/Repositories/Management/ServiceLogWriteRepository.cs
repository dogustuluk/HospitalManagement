using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ServiceLogWriteRepository : WriteRepository<ServiceLog>, IServiceLogWriteRepository
    {
        public ServiceLogWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
