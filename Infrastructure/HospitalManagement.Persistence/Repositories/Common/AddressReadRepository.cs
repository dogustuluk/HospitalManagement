using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class AddressReadRepository : ReadRepository<Address>, IAddressReadRepository
    {
        public AddressReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
