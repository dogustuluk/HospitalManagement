using AutoMapper;
using HospitalManagement.Application.DTOs.Management;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateUserCommandRequest, CreateUser_Dto>().ReverseMap();

            CreateMap<Department, GetAllDepartmentQueryResponse>();
            CreateMap<CreateDepartmentCommandRequest, Create_Department_Dto>();

        }
    }
}
