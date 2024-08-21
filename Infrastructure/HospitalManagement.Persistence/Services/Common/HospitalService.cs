using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalReadRepository _readRepository;
        private readonly IHospitalWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly HospitalSpecifications _hospitalSpecifications;

        public HospitalService(IHospitalReadRepository readRepository, IHospitalWriteRepository writeRepository, IMapper mapper, HospitalSpecifications hospitalSpecifications)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _hospitalSpecifications = hospitalSpecifications;
        }

        public async Task<OptResult<Hospital>> CreateHospitalAsync(CreateHospital_Dto model)
        {
            Hospital mappedModel = _mapper.Map<Hospital>(model);
            await _writeRepository.AddAsync(mappedModel);
            await _writeRepository.SaveChanges();
            return await OptResult<Hospital>.SuccessAsync(mappedModel);
        }
        public async Task<OptResult<Hospital>> UpdateHospitalAsync(UpdateHospital_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myHospital = await _readRepository.GetByGuidAsync(model.Guid);
                if (myHospital == null)
                    return await OptResult<Hospital>.FailureAsync(Messages.UnSuccessfull);

                Hospital mappedModel = _mapper.Map(model, myHospital);
                mappedModel.UpdatedUser = Guid.NewGuid(); //test

                var updatedModel = _writeRepository.Update(mappedModel);
                if (updatedModel == null)
                    return await OptResult<Hospital>.FailureAsync(Messages.UnSuccessfull);


                var result = await _writeRepository.SaveChanges();
                if (result > 0)
                    return await OptResult<Hospital>.SuccessAsync(mappedModel);
                else
                    return await OptResult<Hospital>.FailureAsync(Messages.UnSuccessfull);
            });
        }
        public async Task<List<Hospital>> GetAllHospital(Expression<Func<Hospital, bool>>? predicate, string? include)
        {
            var hospitals = await _readRepository.GetAllAsync(predicate, include);
            return await hospitals.ToListAsync();
        }

        public async Task<OptResult<PaginatedList<Hospital>>> GetAllPagedListAsync(GetAllPagedHospital_Index_Dto model)
        {
            var predicate = _hospitalSpecifications.GetAllPagedPredicate(model);
            if (string.IsNullOrEmpty(model.OrderBy)) model.OrderBy = "HospitalName ASC";

            PaginatedList<Hospital> pagedDepartments;

            pagedDepartments = await _readRepository.GetDataPagedAsync(predicate, "", model.PageIndex, model.Take, model.OrderBy);

            return await OptResult<PaginatedList<Hospital>>.SuccessAsync(pagedDepartments, Messages.Successfull);
        }

        public async Task<OptResult<Hospital>> GetByIdOrGuid(object criteria)
        {
            if (criteria == null)
                return await OptResult<Hospital>.FailureAsync(Messages.NullValue);

            Hospital myHospital = null;

            if (criteria is Guid guid)
                myHospital = await _readRepository.GetByGuidAsync(guid);
            else if (criteria is int id)
                myHospital = await _readRepository.GetByIdAsync(id);

            if (myHospital == null)
                return await OptResult<Hospital>.FailureAsync(Messages.NullData);

            return await OptResult<Hospital>.SuccessAsync(myHospital);
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            List<DataList1> returnDataList = new();

            var datas = await _readRepository.GetDataAsync(a => a.Id > 0, "", 10000, "HospitalName ASC");
            foreach (var data in datas)
            {
                returnDataList.Add(new DataList1() { Guid = "", Id = data.Id.ToString(), Name = data.HospitalName });
            }
            return returnDataList;
        }

        public async Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType)
        {
            var data = await _readRepository.GetValueAsync("Hospitals", column, sqlQuery, 1);
            if (data != null) return data;
            return Messages.NullData;
        }
    }
}
