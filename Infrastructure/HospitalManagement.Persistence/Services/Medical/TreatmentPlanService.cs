using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class TreatmentPlanService : ITreatmentPlanService
    {
        private readonly ITreatmentPlanReadRepository _readRepository;
        private readonly ITreatmentPlanWriteRepository _writeRepository;

        public TreatmentPlanService(ITreatmentPlanReadRepository readRepository, ITreatmentPlanWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
