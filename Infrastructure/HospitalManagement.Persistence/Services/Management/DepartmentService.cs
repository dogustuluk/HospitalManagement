using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Common.DTOs.Management;
using HospitalManagement.Application.Common.DTOs.User;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Application.Settings;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Threading;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IDepartmentWriteRepository _writeRepository;

        public DepartmentService(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
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
    }
}
