namespace HospitalManagement.Application.Features.Commands.Announcement.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommandRequest, OptResult<UpdateAnnouncementCommandResponse>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public UpdateAnnouncementCommandHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<UpdateAnnouncementCommandResponse>> Handle(UpdateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
                {
                    var updateAnnouncementDto = _mapper.Map<Update_Announcemnet_Dto>(request);

                    var updatedAnnouncement = await _announcementService.UpdateAnnouncementAsync(updateAnnouncementDto);

                    if (!updatedAnnouncement.Succeeded)
                        return await OptResult<UpdateAnnouncementCommandResponse>.FailureAsync(Messages.UnSuccessfull);

                    var response = _mapper.Map<UpdateAnnouncementCommandResponse>(updatedAnnouncement.Data);
                    return await OptResult<UpdateAnnouncementCommandResponse>.SuccessAsync(response, Messages.SuccessfullyUpdated);
                });
        }
    }
}
