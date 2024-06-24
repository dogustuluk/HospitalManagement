using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class ItemTypeWriteRepository : WriteRepository<ItemType>, IItemTypeWriteRepository
    {
        public ItemTypeWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
