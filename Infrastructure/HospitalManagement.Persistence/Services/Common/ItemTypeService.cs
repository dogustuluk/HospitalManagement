﻿using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeReadRepository _readRepository;
        private readonly IItemTypeWriteRepository _writeRepository;

        public ItemTypeService(IItemTypeReadRepository readRepository, IItemTypeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
    }
}
