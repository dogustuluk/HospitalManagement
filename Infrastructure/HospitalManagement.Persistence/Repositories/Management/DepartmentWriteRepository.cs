using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
