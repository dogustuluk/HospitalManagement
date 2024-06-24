using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ItemChangeWriteRepository : WriteRepository<ItemChange>, IItemChangeWriteRepository
    {
        public ItemChangeWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
