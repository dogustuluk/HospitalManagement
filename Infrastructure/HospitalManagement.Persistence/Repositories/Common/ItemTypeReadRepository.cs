using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class ItemTypeReadRepository : ReadRepository<ItemType>, IItemTypeReadRepository
    {
        public ItemTypeReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
