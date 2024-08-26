global using System;
global using System.Text;
global using System.Reflection;
global using System.Collections.Generic;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Threading.Tasks;
global using System.Linq.Dynamic.Core;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using FluentValidation;
global using MediatR;
global using AutoMapper;
global using LinqKit;
global using Microsoft.IdentityModel.Tokens;
global using System.Security.Cryptography;

global using HospitalManagement.Application;
global using HospitalManagement.Application.Abstractions.Security;
global using HospitalManagement.Application.Abstractions.Services.Appointment;
global using HospitalManagement.Application.Abstractions.Services.Auth;
global using HospitalManagement.Application.Abstractions.Services.Common;
global using HospitalManagement.Application.Abstractions.Services.Management;
global using HospitalManagement.Application.Abstractions.Services.Medical;
global using HospitalManagement.Application.Abstractions.Services.Users;
global using HospitalManagement.Application.Abstractions.Token;
global using HospitalManagement.Application.Common.DTOs;
global using HospitalManagement.Application.Common.DTOs.Management;
global using HospitalManagement.Application.Common.DTOs.User;
global using HospitalManagement.Application.Common.Extensions;
global using HospitalManagement.Application.Common.GenericObjects;
global using HospitalManagement.Application.Common.Mappings;
global using HospitalManagement.Application.Common.Specifications;
global using HospitalManagement.Application.Common.Validators;
global using HospitalManagement.Application.Common.Validators.Management;
global using HospitalManagement.Application.Constants;
global using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
global using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
global using HospitalManagement.Application.Features.Commands.User.AppUser.LoginUser;
global using HospitalManagement.Application.Features.Commands.User.AppUser.RefreshTokenLogin;
global using HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser;
global using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
global using HospitalManagement.Application.Features.Queries.Department.GetDataList;
global using HospitalManagement.Application.Features.Queries.Department.GetDataPagedList;
global using HospitalManagement.Application.Repositories;
global using HospitalManagement.Application.Repositories.Appointment;
global using HospitalManagement.Application.Repositories.Common;
global using HospitalManagement.Application.Repositories.Management;
global using HospitalManagement.Application.Repositories.Medical;
global using HospitalManagement.Application.Services;
global using HospitalManagement.Application.Attributes;
global using HospitalManagement.Application.Utilities.Security.Encryption;
global using HospitalManagement.Application.Utilities.Security.JWT;

global using HospitalManagement.Domain.Entities.Appointment;
global using HospitalManagement.Domain.Entities.Common;
global using HospitalManagement.Domain.Entities.Identity;
global using HospitalManagement.Domain.Entities.Management;
global using HospitalManagement.Domain.Entities.Medical;
global using HospitalManagement.Domain.Enums;
