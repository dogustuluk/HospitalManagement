namespace HospitalManagement.Application.Features.Commands.Announcement.DeleteAnnouncement;

public class DeleteAnnouncementCommandRequest : IRequest<OptResult<DeleteAnnouncementCommandResponse>>
{
    public int? Id { get; set; }
    public Guid? Guid { get; set; }
}