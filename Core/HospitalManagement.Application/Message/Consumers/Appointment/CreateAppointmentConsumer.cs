using HospitalManagement.Application.Common.DTOs.Appointment;
using HospitalManagement.Application.Message.Commands.Appointment;
using HospitalManagement.Application.Message.Events.Appointments;
using MassTransit;

namespace HospitalManagement.Application.Message.Consumers.Appointment;
public class CreateAppointmentConsumer : IConsumer<CreateAppointmentMessage>
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;


    public CreateAppointmentConsumer(IAppointmentService appointmentService, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<CreateAppointmentMessage> context)
    {
        var dto = _mapper.Map<CreateAppointment_Dto>(context.Message);

        var result = await _appointmentService.CreateAppointmentAsync(dto);


        //event
        var appointmentCreatedEvent = new CreatedAppointmentEvent
        {
            AppointmentDate = result.Data.AppointmentDate,
            AppointmentId = result.Data.Guid,
            CreatedUser = result.Data.CreatedUser,

        };
        if (result.Succeeded)
        {
            Console.WriteLine("randevu ekleme başarılı:", result.Data);
            appointmentCreatedEvent.Status = "Created";
            appointmentCreatedEvent.Message = "Randevu Başarıyla Oluşturuldu";
        }
        if (!result.Succeeded)
        {
            Console.WriteLine("randevu ekleme başarısız:", result.Data);
            appointmentCreatedEvent.Status = "Failed";
            appointmentCreatedEvent.Message = "Randevu Oluşturulamadı";
        }
        await _publishEndpoint.Publish(appointmentCreatedEvent);
    }
}
