namespace HospitalManagement.Application.Features.Queries.Announcement.GetValueAnnouncement
{
    public class GetValueAnnouncementQueryRequest : IRequest<OptResult<GetValueAnnouncementQueryResponse>>
    {
        public string ColumnName { get; set; }
        public int DataId { get; set; }
    }
}