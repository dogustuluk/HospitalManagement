﻿using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Application.Abstractions.Services.Common
{
    public interface IErrorService
    {
        Task<OptResult<Error>> AddErrorAsync(Create_Error_Dto model);
        Task<OptResult<PaginatedList<Error>>> GetAllPagedErrorAsync(GetAllPaged_Error_Dto model);
    }
}
