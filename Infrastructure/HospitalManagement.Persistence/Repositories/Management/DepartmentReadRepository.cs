using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;
namespace HospitalManagement.Persistence.Repositories.Management
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
