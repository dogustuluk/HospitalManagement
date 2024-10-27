using AutoMapper;
using HospitalManagement.Application.Abstractions.Caching;
using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Application.Common.DTOs.Management;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IDepartmentWriteRepository _writeRepository;
        private readonly DepartmentSpecifications _departmentSpecifications;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, DepartmentSpecifications departmentSpecifications, IRedisCacheService redisCacheService, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _departmentSpecifications = departmentSpecifications;
            _redisCacheService = redisCacheService;
            _mapper = mapper;
        }

        public async Task<OptResult<Create_Department_Dto>> CreateDepartment(Create_Department_Dto create_Department)
        {
            var newDepartment = new Department
            {
                CreatedDate = DateTime.UtcNow,
                CreatedUser = Guid.NewGuid(),
                DepartmentCode = create_Department.DepartmentCode,
                DepartmentName = create_Department.DepartmentName,
                Guid = Guid.NewGuid(),
                isActive = true,
                ManagerMemberId = create_Department.ManagerMemberId,
                Param1 = create_Department.Param1,
                Param2 = create_Department.Param2,
                ParentId = create_Department.ParentId,
                SortOrderNo = create_Department.SortOrderNo,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid() //jwt'den al kullanıcıyı
            };

            await _writeRepository.AddAsync(newDepartment);
            await _writeRepository.SaveChanges();

            var createdDepartmentDto = new Create_Department_Dto
            {
                DepartmentCode = newDepartment.DepartmentCode,
                DepartmentName = newDepartment.DepartmentName,
                ManagerMemberId = newDepartment.ManagerMemberId,
                Param1 = newDepartment.Param1,
                Param2 = newDepartment.Param2,
                ParentId = newDepartment.ParentId,
                SortOrderNo = newDepartment.SortOrderNo,
            };
            return await OptResult<Create_Department_Dto>.SuccessAsync(createdDepartmentDto, Messages.Successfull);
        }

        public async Task<List<Department>> GetAllDepartment(Expression<Func<Department, bool>>? predicate, string? include)
        {
            var departments = await _readRepository.GetAllAsync(predicate, include);
            return departments.ToList();
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            List<DataList1> returnDataList = new();
            var datas = await _readRepository.GetDataAsync(a => a.Id > 0, "", 5000, "DepartmentName ASC");
            foreach (var data in datas)
            {
                returnDataList.Add(new DataList1() { Guid = "", Id = data.Id.ToString(), Name = data.DepartmentName });
            }
            return returnDataList;
        }

        public async Task<OptResult<PaginatedList<Department>>> GetDataPagedForDepartment(GetAllPaged_Index_Dto model)
        {
            var predicate = _departmentSpecifications.GetDataPagedListPredicate(model);
            if (string.IsNullOrEmpty(model.OrderBy)) model.OrderBy = "DepartmentName ASC";

            PaginatedList<Department> pagedDepartments;

            //redisteki index page kısmını çöz
            if (!string.IsNullOrEmpty(model.SearchText) || model.OrderBy != "Id ASC" || model.ParentID != -99 || model.ManagerMemberID > 0 || model.PageIndex != 1 ||!_redisCacheService.IsConnected)
                pagedDepartments = await _readRepository.GetDataPagedAsync(predicate, "", model.PageIndex, model.Take, model.OrderBy);
            else
                pagedDepartments = await _redisCacheService.GetPaginatedListAsync("departments", model.PageIndex, async pageIndex =>
                   await _readRepository.GetDataPagedAsync(predicate, "", pageIndex, model.Take, model.OrderBy));

            return await OptResult<PaginatedList<Department>>.SuccessAsync(pagedDepartments, Messages.Successfull);
        }

        public async Task<OptResult<Department>> UpdateDepartmentAsync(Update_Department_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                Department myDepartment = await _readRepository.GetByGuidAsync(model.Guid);
                if (myDepartment == null) return await OptResult<Department>.FailureAsync(Messages.NullData);
                
                Department mappedDepartment = _mapper.Map(model, myDepartment);
                mappedDepartment.UpdatedDate = DateTime.UtcNow;
                mappedDepartment.UpdatedUser = Guid.NewGuid();//test

                var updatedDepartment = _writeRepository.Update(mappedDepartment);
                var result = await _writeRepository.SaveChanges();
                if (result > 0)
                    return await OptResult<Department>.SuccessAsync(mappedDepartment, Messages.SuccessfullyUpdated);
                
                return await OptResult<Department>.FailureAsync(Messages.UnSuccessfull);
            });
        }
    }
}
