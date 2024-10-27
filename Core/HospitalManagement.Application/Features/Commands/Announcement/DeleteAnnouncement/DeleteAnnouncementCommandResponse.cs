namespace HospitalManagement.Application.Features.Commands.Announcement.DeleteAnnouncement;

public class DeleteAnnouncementCommandResponse
{
    public string AnnouncementName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}