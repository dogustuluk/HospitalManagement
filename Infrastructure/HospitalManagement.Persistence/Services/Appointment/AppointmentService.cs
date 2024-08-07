using AutoMapper;
using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Application.Settings;
using HospitalManagement.Domain.Entities.Appointment;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

namespace HospitalManagement.Persistence.Services.Appointment
{
    [Service(ServiceLifetime.Scoped)]
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository _readRepository;
        private readonly IAppointmentWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentReadRepository readRepository, IAppointmentWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateAppointment_Dto>> CreateAppointmentAsync(CreateAppointment_Dto Model)
        {
            Domain.Entities.Appointment.Appointment appointment = Model.UserType switch
            {
                5 => _mapper.Map<VisitorAppointment>(Model),
                6 => _mapper.Map<ExaminationAppointment>(Model),
                _ => throw new ArgumentException("Invalid UserType")
            };

            appointment.Guid = Guid.NewGuid();
            appointment.CreatedUser = Guid.NewGuid();
            appointment.CreatedDate = DateTime.UtcNow;
            //appointment.AppointmentDate = Model.AppointmentDate;

            await _writeRepository.AddAsync(appointment);
            await _writeRepository.SaveChanges();

            var createAppointmentResponse = _mapper.Map<CreateAppointment_Dto>(appointment);

            return await OptResult<CreateAppointment_Dto>.SuccessAsync(createAppointmentResponse, Messages.SuccessfullyAdded);

        }
    }
}
