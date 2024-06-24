﻿using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Common
{
    public class DbParameterWriteRepository : WriteRepository<DbParameter>, IDbParameterWriteRepository
    {
        public DbParameterWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
