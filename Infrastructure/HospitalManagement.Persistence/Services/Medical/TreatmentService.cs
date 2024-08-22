using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentReadRepository _readRepository;
        private readonly ITreatmentWriteRepository _writeRepository;

        public TreatmentService(ITreatmentReadRepository readRepository, ITreatmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
