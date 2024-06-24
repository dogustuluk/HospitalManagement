using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class CountyWriteRepository : WriteRepository<County>, ICountyWriteRepository
    {
        public CountyWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
