using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.DTOs.Management;
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

        public DepartmentService(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task CreateDepartment(Create_Department_Dto create_Department)
        {
            await _writeRepository.AddAsync(new()
            {
                CreatedDate = DateTime.UtcNow,
                CreatedUser = Guid.NewGuid(),
                DepartmentCode = create_Department.DepartmentCode,
                DepartmentName = create_Department.DepartmentName,
                Guid = Guid.NewGuid(),
                isActive = true,
                ManagerMemberId = 1,
                Param1 = create_Department.Param1,
                Param2 = create_Department.Param2,
                ParentId = create_Department.ParentId,
                SortOrderNo = create_Department.SortOrderNo,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });
            await _writeRepository.SaveChanges();
        }

        public async Task<List<Department>> GetAllDepartment(Expression<Func<Department, bool>>? predicate, string? include)
        {
            var departments = await _readRepository.GetAllAsync(predicate, include);
            return departments.ToList();
        }
    }
}
