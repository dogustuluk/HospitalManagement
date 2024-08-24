namespace HospitalManagement.Application.Common.DTOs.Management
{
    public class GetAllPaged_Announcement_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }       
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
    public class Create_Announcemnet_Dto
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
    public class Update_Announcemnet_Dto
    {
        public Guid Guid { get; set; }
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
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    
}
