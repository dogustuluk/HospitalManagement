using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
