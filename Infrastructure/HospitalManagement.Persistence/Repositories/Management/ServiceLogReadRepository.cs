using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ServiceLogReadRepository : ReadRepository<ServiceLog>, IServiceLogReadRepository
    {
        public ServiceLogReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
