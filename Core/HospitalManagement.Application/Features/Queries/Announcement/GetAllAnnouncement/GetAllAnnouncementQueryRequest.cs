namespace HospitalManagement.Application.Features.Queries.Announcement.GetAllAnnouncement
{
    public class GetAllAnnouncementQueryRequest : IRequest<OptResult<List<GetAllAnnouncementQueryResponse>>>
    {
        public string? OrderBy { get; set; } = "Id DESC";
        public Dictionary<string, string>? Filters { get; set; }
    }
}