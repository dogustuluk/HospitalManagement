﻿namespace HospitalManagement.Application.Features.Commands.Announcement.CrearteAnnouncement
{
    public class CreateAnnouncementCommandRequest : IRequest<OptResult<CreateAnnouncementCommandResponse>>
    {
        public string UserTypeIds { get; set; }
        public string AnnouncementTitle { get; set; }
        public string? AnnouncementSummary { get; set; }
        public string? AnnouncementContent { get; set; }
        public string? FilePath { get; set; }
        public DateTime VisibleDate { get; set; }
        public int VisibleDays { get; set; }
        public bool isSpot { get; set; }
        public bool isMustAccept { get; set; }
        public string? ReadLogs { get; set; }
        public bool isActive { get; set; }
    }
}