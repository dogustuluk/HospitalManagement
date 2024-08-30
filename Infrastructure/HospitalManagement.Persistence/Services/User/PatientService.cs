using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Users;
using HospitalManagement.Application.Attributes;
using HospitalManagement.Application.Common.DTOs.User;
using HospitalManagement.Application.Common.Extensions;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence.Services.User
{
    [Service(ServiceLifetime.Scoped)]
    public class PatientService : IPatientService
    {
        private readonly IPatientReadRepository _readRepository;
        private readonly IPatientWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientReadRepository readRepository, IPatientWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<Patient>> CreateAsync(Create_Patient_Dto model)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedModel = _mapper.Map<Patient>(model);
                await _writeRepository.AddAsync(mappedModel);
                await _writeRepository.SaveChanges();
                return await OptResult<Patient>.SuccessAsync(mappedModel);
            });
        }
    }
}
