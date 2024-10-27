
namespace HospitalManagement.Application.Features.Commands.Announcement.DeleteAnnouncement;
public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommandRequest, OptResult<DeleteAnnouncementCommandResponse>>
{
    private readonly IAnnouncementService _announcementService;
    private readonly IMapper _mapper;

    public DeleteAnnouncementCommandHandler(IAnnouncementService announcementService, IMapper mapper)
    {
        _announcementService = announcementService;
        _mapper = mapper;
    }

    public async Task<OptResult<DeleteAnnouncementCommandResponse>> Handle(DeleteAnnouncementCommandRequest request, CancellationToken cancellationToken)
    {
        return await ExceptionHandler.HandleOptResultAsync(async () =>
        {
            var data = await _announcementService.DeleteAnnouncementAsync(request.Guid, 1);
            var mappedData = _mapper.Map<DeleteAnnouncementCommandResponse>(data.Data);
            if (mappedData == null) return await OptResult<DeleteAnnouncementCommandResponse>.FailureAsync(Messages.NullData);
            return await OptResult<DeleteAnnouncementCommandResponse>.SuccessAsync(mappedData, Messages.SuccessfullyDeleted);
        });
    }
}
