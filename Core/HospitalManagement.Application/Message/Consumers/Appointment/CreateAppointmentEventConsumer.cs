using HospitalManagement.Application.Message.Events.Appointments;
using MassTransit;

namespace HospitalManagement.Application.Message.Consumers.Appointment;
public class CreateAppointmentEventConsumer : IConsumer<CreatedAppointmentEvent>
{
    private readonly IServiceLogService _serviceLogService;

    public CreateAppointmentEventConsumer(IServiceLogService serviceLogService)
    {
        _serviceLogService = serviceLogService;
    }

    public async Task Consume(ConsumeContext<CreatedAppointmentEvent> context)
    {
        var log = new Create_ServiceLog_Dto
        {
            LogType = 1,
            FunctionName = context.Message.Status,
            OptIds = context.Message.AppointmentId.ToString(),
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            CreatedUser = Guid.NewGuid(),
            UpdatedUser = Guid.NewGuid()
        };
        await _serviceLogService.CreateLogAsync(log);
    }
}
