﻿using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class StatusService : IStatusService
    {
        private readonly IStatusReadRepository _readRepository;
        private readonly IStatusWriteRepository _writeRepository;

        public StatusService(IStatusReadRepository readRepository, IStatusWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
