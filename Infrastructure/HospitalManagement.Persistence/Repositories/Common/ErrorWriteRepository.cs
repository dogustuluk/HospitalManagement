using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class ErrorWriteRepository : WriteRepository<Error>, IErrorWriteRepository
    {
        public ErrorWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
