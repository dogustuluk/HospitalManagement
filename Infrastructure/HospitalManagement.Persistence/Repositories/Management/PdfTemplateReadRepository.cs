using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class PdfTemplateReadRepository : ReadRepository<PdfTemplate>, IPdfTemplateReadRepository
    {
        public PdfTemplateReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
