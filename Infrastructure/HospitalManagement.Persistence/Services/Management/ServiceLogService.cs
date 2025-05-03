using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Application.Common.DTOs.Management;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Repositories.Management;
using HospitalManagement.Domain.Entities.Management;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.Management
{
    [Service(ServiceLifetime.Scoped)]
    public class ServiceLogService : IServiceLogService
    {
        private readonly IServiceLogReadRepository _readRepository;
        private readonly IServiceLogWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public ServiceLogService(IServiceLogReadRepository readRepository, IServiceLogWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<ServiceLog>> CreateLogAsync(Create_ServiceLog_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedModel = _mapper.Map<ServiceLog>(model);

                var data = await _writeRepository.AddAsyncReturnEntity(mappedModel);
                await _writeRepository.SaveChanges();
                return await OptResult<ServiceLog>.SuccessAsync(data);
            });
        }
    }
}
