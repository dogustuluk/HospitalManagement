using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;

namespace HospitalManagement.Application.Features.Commands.Announcement.CrearteAnnouncement
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommandRequest, OptResult<CreateAnnouncementCommandResponse>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public CreateAnnouncementCommandHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateAnnouncementCommandResponse>> Handle(CreateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<Create_Announcemnet_Dto>(request);
                var data = await _announcementService.CreateAnnouncementAsync(mappedDto);
                if (!data.Succeeded)
                    return await OptResult<CreateAnnouncementCommandResponse>.FailureAsync(Messages.UnSuccessfull);
                var response = _mapper.Map<CreateAnnouncementCommandResponse>(data.Data);
                return await OptResult<CreateAnnouncementCommandResponse>.SuccessAsync(response);
            });
        }
    }
}
