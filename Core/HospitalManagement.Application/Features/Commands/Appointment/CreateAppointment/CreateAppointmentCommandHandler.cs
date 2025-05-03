using HospitalManagement.Application.Message.Commands.Appointment;
using MassTransit;

namespace HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, OptResult<CreateAppointmentCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateAppointmentCommandHandler(IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<OptResult<CreateAppointmentCommandResponse>> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            // OptResult<CreateAppointmentCommandResponse> response = new OptResult<CreateAppointmentCommandResponse>();
            var message = _mapper.Map<CreateAppointmentMessage>(request);

            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                await _publishEndpoint.Publish(message, cancellationToken);
                var response = new CreateAppointmentCommandResponse
                {

                    Message = "Randevu isteğiniz işleme alındı."
                };

                return await OptResult<CreateAppointmentCommandResponse>.SuccessAsync(response);

            });
        }
    }
}