using HospitalManagement.Application.Abstractions.Caching;
using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Common.DTOs.Management;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Settings;
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

        public DepartmentService(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, DepartmentSpecifications departmentSpecifications, IRedisCacheService redisCacheService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _departmentSpecifications = departmentSpecifications;
            _redisCacheService = redisCacheService;
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

            var pagedDepartments = await _redisCacheService.GetPaginatedListAsync("departments", model.PageIndex, async pageIndex => await _readRepository.GetDataPagedAsync(predicate, "", pageIndex, model.Take, model.OrderBy));

            return await OptResult<PaginatedList<Department>>.SuccessAsync(pagedDepartments, Messages.Successfull);
        }
    }
}
