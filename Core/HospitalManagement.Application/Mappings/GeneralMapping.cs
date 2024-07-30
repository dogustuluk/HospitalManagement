﻿using AutoMapper;
using HospitalManagement.Application.DTOs.Management;
using HospitalManagement.Application.DTOs.User;
using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser;
using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CreateMap<CreateUserCommandRequest, CreateUser_Dto>().ReverseMap();
            //CreateMap<CreateUser_Dto, CreateUserCommandResponse>();
            CreateMap<CreateUserCommandRequest, CreateUser_Dto>()
            .ForMember(dest => dest.Guid, opt => opt.Ignore());
            CreateMap<CreateUser_Dto, CreateUserCommandResponse>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid));

            CreateMap<UpdateUserCommandRequest, UpdateUser_Dto>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommandResponse>().ReverseMap();
            CreateMap<UpdateUser_Dto, UpdateUserCommandResponse>();

            CreateMap<Department, GetAllDepartmentQueryResponse>();
            CreateMap<CreateDepartmentCommandRequest, Create_Department_Dto>();

        }
    }
}
