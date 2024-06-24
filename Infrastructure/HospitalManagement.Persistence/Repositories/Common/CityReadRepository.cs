using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CityReadRepository : ReadRepository<City>, ICityReadRepository
    {
        public CityReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
