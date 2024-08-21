namespace HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement
{
    public class GetAllPagedAnnouncementQueryRequest : IRequest<OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}