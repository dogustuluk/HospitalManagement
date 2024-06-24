using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class ItemChangeReadRepository : ReadRepository<ItemChange>, IItemChangeReadRepository
    {
        public ItemChangeReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
