namespace HospitalManagement.Application.Features.Queries.Announcement.GetByIdorGuidAnnouncement
{
    public class GetByIdOrGuidAnnouncementQueryRequest : IRequest<OptResult<GetByIdOrGuidAnnouncementQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? guid { get; set; }
    }
}