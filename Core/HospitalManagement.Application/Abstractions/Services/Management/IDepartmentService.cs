using HospitalManagement.Application.DTOs.Management;
using HospitalManagement.Domain.Entities.Management;
using System.Linq.Expressions;

namespace HospitalManagement.Application.Abstractions.Services.Management
{
    public interface IDepartmentService
    {
        Task CreateDepartment(Create_Department_Dto create_Department);
        Task<List<Department>> GetAllDepartment(Expression<Func<Department, bool>>? predicate, string? include);
    }
}
