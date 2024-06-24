using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Management
{
    public class PdfTemplateWriteRepository : WriteRepository<PdfTemplate>, IPdfTemplateWriteRepository
    {
        public PdfTemplateWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
