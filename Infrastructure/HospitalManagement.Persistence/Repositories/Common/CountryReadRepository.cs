using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CountryReadRepository : ReadRepository<Country>, ICountryReadRepository
    {
        public CountryReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
