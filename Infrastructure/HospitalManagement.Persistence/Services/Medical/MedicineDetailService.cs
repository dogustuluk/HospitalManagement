using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Common.DTOs.Medical;
using AutoMapper;
using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class MedicineDetailService : IMedicineDetailService
    {
        private readonly IMedicineDetailReadRepository _readRepository;
        private readonly IMedicineDetailWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public MedicineDetailService(IMedicineDetailReadRepository readRepository, IMedicineDetailWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<MedicineDetail>> AddMedicineDetail(Add_MedicineDetail_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedModel = _mapper.Map<MedicineDetail>(model);

                bool isExist = await _readRepository.ExistsAsync(
                    a => a.Ingredients == mappedModel.Ingredients &&
                    a.SideEffects == mappedModel.SideEffects && a.SpecialInstructionsForUse == mappedModel.SpecialInstructionsForUse);
                if (isExist)
                    return await OptResult<MedicineDetail>.FailureAsync(Messages.AddedDataIsAlready);


                await _writeRepository.AddAsyncReturnEntity(mappedModel);
                await _writeRepository.SaveChanges();
                return await OptResult<MedicineDetail>.SuccessAsync(mappedModel);
            });
        }

        public Task<OptResult<MedicineDetail>> DeleteMedicineDetail(int id, bool? isHardDelete = false)
        {
            throw new NotImplementedException();
        }

        public async Task<OptResult<MedicineDetail>> GetMedicineDetail(int id)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myMedicineDetail = await _readRepository.GetSingleEntityAsync(a => a.MedicineId == id);
                if (myMedicineDetail == null)
                    return await OptResult<MedicineDetail>.FailureAsync(Messages.UnSuccessfull);
                return await OptResult<MedicineDetail>.SuccessAsync(myMedicineDetail);
            });
        }

        public Task<OptResult<MedicineDetail>> UpdateMedicineDetail(Update_MedicineDetail_Dto model)
        {
            throw new NotImplementedException();
        }
    }
}
