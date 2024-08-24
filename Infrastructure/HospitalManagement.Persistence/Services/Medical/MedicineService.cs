using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Medical;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace HospitalManagement.Persistence.Services.Medical
{
    [Service(ServiceLifetime.Scoped)]
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineReadRepository _readRepository;
        private readonly IMedicineWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly MedicineSpecifications _medicineSpecifications;

        public MedicineService(IMedicineReadRepository readRepository, IMedicineWriteRepository writeRepository, IMapper mapper, MedicineSpecifications medicineSpecifications)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _medicineSpecifications = medicineSpecifications;
        }

        public async Task<OptResult<Medicine>> CreateMedicineAsync(Create_Medicine_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                Medicine mappedDto = _mapper.Map<Medicine>(model);

                var createdMedicine = await _writeRepository.AddAsyncReturnEntity(mappedDto);
                createdMedicine.MedicineDetailId = createdMedicine.MedicineDetail.Id;

                int saveMedicine = await _writeRepository.SaveChanges();

                return await OptResult<Medicine>.SuccessAsync(mappedDto);
            });
        }

        public async Task<OptResult<Medicine>> UpdateMedicineAsync(Update_Medicine_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myMedicine = await _readRepository.GetByGuidAsync(model.Guid);
                if (myMedicine == null)
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);

                Medicine mappedModel = _mapper.Map(model, myMedicine);

                var targetMedicines = await _readRepository.GetAllAsync(a => a.Id != myMedicine.Id && a.MedicineCategory == model.MedicineCategory && a.MedicineType == model.MedicineType, "");
                
                //---------------------------------hatalı suan
                if (targetMedicines != null)
                {
                    var duplicateDatas = await _readRepository.GetAllSpecificPropertiesAsync(
                    targetMedicines,
                    predicate:
                        a => a.Id != myMedicine.Id &&
                        a.Name == model.Name &&
                        //a.IsPrescriptionRequired == model.IsPrescriptionRequired &&
                        a.MedicineDetail.Ingredients == model.MedicineDetail.Ingredients //&&
                        //a.MedicineDetail.SideEffects == model.MedicineDetail.SideEffects &&
                        //a.MedicineDetail.SpecialInstructionsForUse == model.MedicineDetail.SpecialInstructionsForUse
                        ,
                    "",
                    selector: x => new { x.Id });
                    var isExist = await duplicateDatas.ToListAsync();

                    if (duplicateDatas != null && duplicateDatas.Any())
                        return await OptResult<Medicine>.FailureAsync(Messages.UpdatedDataIsAlready);
                    
                }
                

                var guid = Guid.NewGuid();
                mappedModel.UpdatedUser = guid; //test
                mappedModel.MedicineDetail.UpdatedUser = guid; //test

                var updatedModel = _writeRepository.Update(mappedModel);
                if (updatedModel == null)
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);

                var result = await _writeRepository.SaveChanges();
                if (result > 0)
                    return await OptResult<Medicine>.SuccessAsync(mappedModel);
                else
                    return await OptResult<Medicine>.FailureAsync(Messages.UnSuccessfull);
            });
        }

        public async Task<List<Medicine>> GetAllMedicine(Expression<Func<Medicine, bool>>? predicate, string? include)
        {
            var medicines = await _readRepository.GetAllAsync(predicate, include);
            return await medicines.ToListAsync();
        }

        public async Task<OptResult<PaginatedList<Medicine>>> GetAllPagedListAsync(GetAllPaged_Medicine_Index_Dto model)
        {
            var predicate = _medicineSpecifications.GetAllPagedPredicate(model);
            if (string.IsNullOrEmpty(model.OrderBy)) model.OrderBy = "Name ASC";

            PaginatedList<Medicine> pagedMedicines;

            pagedMedicines = await _readRepository.GetDataPagedAsync(predicate, "", model.PageIndex, model.Take, model.OrderBy, true);

            return await OptResult<PaginatedList<Medicine>>.SuccessAsync(pagedMedicines, Messages.Successfull);
        }

        public async Task<OptResult<Medicine>> GetByIdOrGuid(object criteria)
        {
            if (criteria == null)
                return await OptResult<Medicine>.FailureAsync(Messages.NullValue);

            Medicine myMedicine = null;

            if (criteria is Guid guid)
                myMedicine = await _readRepository.GetByGuidAsync(guid);
            else if (criteria is int id)
                myMedicine = await _readRepository.GetByIdAsync(id);

            if (myMedicine == null)
                return await OptResult<Medicine>.FailureAsync(Messages.NullData);

            return await OptResult<Medicine>.SuccessAsync(myMedicine);
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            List<DataList1> returnDataList = new();

            var datas = await _readRepository.GetDataAsync(a => a.Id > 0, "", 100000, "Name ASC");
            foreach (var data in datas)
            {
                returnDataList.Add(new DataList1() { Guid = "", Id = data.Id.ToString(), Name = data.Name });
            }
            return returnDataList;
        }

        public async Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType)
        {
            var data = await _readRepository.GetValueAsync("Medicines", column, sqlQuery, 1);
            if (data != null) return data;
            return Messages.NullData;
        }
    }
}