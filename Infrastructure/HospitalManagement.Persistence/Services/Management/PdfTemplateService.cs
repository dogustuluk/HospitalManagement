using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class PdfTemplateService : IPdfTemplateService
    {
        private readonly IPdfTemplateReadRepository _readRepository;
        private readonly IPdfTemplateWriteRepository _writeRepository;

        public PdfTemplateService(IPdfTemplateReadRepository readRepository, IPdfTemplateWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
