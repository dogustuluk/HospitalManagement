using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.Common.File>, IFileWriteRepository
    {
        public FileWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
