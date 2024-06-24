using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CountryWriteRepository : WriteRepository<Country>, ICountryWriteRepository
    {
        public CountryWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
