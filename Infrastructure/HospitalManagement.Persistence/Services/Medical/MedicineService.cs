using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Domain.Entities.Medical;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineReadRepository _readRepository;
        private readonly IMedicineWriteRepository _writeRepository;
        private readonly IMedicineDetailWriteRepository _medicineDetailWriteRepository;
        private readonly IMapper _mapper;

        public MedicineService(IMedicineReadRepository readRepository, IMedicineWriteRepository writeRepository, IMedicineDetailWriteRepository medicineDetailWriteRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _medicineDetailWriteRepository = medicineDetailWriteRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<Medicine>> CreateMedicineAsync(Create_Medicine_Dto model)
        {
            //tamamlanmadı
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                Medicine mappedDto = _mapper.Map<Medicine>(model);
                
                var createdMedicine = await _writeRepository.AddAsyncReturnEntity(mappedDto);
                int saveMedicine = await _writeRepository.SaveChanges(); 
                if (saveMedicine > 0)
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);

                MedicineDetail mappedMedicineDetail = _mapper.Map<MedicineDetail>(model);
                mappedMedicineDetail.MedicineId = createdMedicine.Id;

                var isDetailAdded = await _medicineDetailWriteRepository.AddAsync(mappedMedicineDetail);
                if (!isDetailAdded)
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);

                int saveMedicineDetail = await _medicineDetailWriteRepository.SaveChanges();
                if (saveMedicineDetail < 0)
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<Medicine>.SuccessAsync(mappedDto);
            });
        }
    }
}
