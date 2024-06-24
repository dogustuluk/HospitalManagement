using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class ErrorReadRepository : ReadRepository<Error>, IErrorReadRepository
    {
        public ErrorReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
