using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CityWriteRepository : WriteRepository<City>, ICityWriteRepository
    {
        public CityWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
