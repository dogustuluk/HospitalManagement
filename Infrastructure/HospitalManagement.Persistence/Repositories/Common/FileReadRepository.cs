using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class FileReadRepository : ReadRepository<Domain.Entities.Common.File>, IFileReadRepository
    {
        public FileReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
