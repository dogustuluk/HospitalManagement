using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class RoomWriteRepository : WriteRepository<Room>, IRoomWriteRepository
    {
        public RoomWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
