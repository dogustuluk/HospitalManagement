using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineReadRepository _readRepository;
        private readonly IMedicineWriteRepository _writeRepository;

        public MedicineService(IMedicineReadRepository readRepository, IMedicineWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
