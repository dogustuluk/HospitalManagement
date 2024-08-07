using HospitalManagement.Application.Common.DTOs.Appointment;

namespace HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, OptResult<CreateAppointmentCommandResponse>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateAppointmentCommandResponse>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            OptResult<CreateAppointmentCommandResponse> response = new OptResult<CreateAppointmentCommandResponse>();
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var createAppointmentDto = _mapper.Map<CreateAppointment_Dto>(request);
                var result = await _appointmentService.CreateAppointmentAsync(createAppointmentDto);
                if (result.Succeeded)
                {
                    var response = _mapper.Map<CreateAppointmentCommandResponse>(result.Data);
                    return await OptResult<CreateAppointmentCommandResponse>.SuccessAsync(response, result.Message);
                }
                return await OptResult<CreateAppointmentCommandResponse>.FailureAsync(result.Messages);
            });
        }
    }
}