namespace HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement
{
    public class GetAllPagedAnnouncementQueryResponse
    {
        public string AnnouncementTitle { get; set; }
        public string? AnnouncementSummary { get; set; }
        public string? AnnouncementContent { get; set; }
        public DateTime VisibleDate { get; set; }
        public bool isActive { get; set; }
    }
}