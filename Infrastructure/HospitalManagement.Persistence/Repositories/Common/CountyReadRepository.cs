using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CountyReadRepository : ReadRepository<County>, ICountyReadRepository
    {
        public CountyReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
