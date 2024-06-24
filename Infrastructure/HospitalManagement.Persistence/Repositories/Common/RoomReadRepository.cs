using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class RoomReadRepository : ReadRepository<Room>, IRoomReadRepository
    {
        public RoomReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
