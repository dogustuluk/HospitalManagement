using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class MedicineDetailService : IMedicineDetailService
    {
        private readonly IMedicineDetailReadRepository _readRepository;
        private readonly IMedicineDetailWriteRepository _writeRepository;

        public MedicineDetailService(IMedicineDetailReadRepository readRepository, IMedicineDetailWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
