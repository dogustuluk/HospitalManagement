using app = HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Application.Features.Queries.Announcement.GetAllAnnouncement
{
    public class GetAllAnnouncementQueryHandler : IRequestHandler<GetAllAnnouncementQueryRequest, OptResult<List<GetAllAnnouncementQueryResponse>>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public GetAllAnnouncementQueryHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetAllAnnouncementQueryResponse>>> Handle(GetAllAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            var dynamicQueryService = new DynamicQueryService();
            var predicate = dynamicQueryService.BuildPredicate<app.Announcement>(request.Filters);

            var announcements = await _announcementService.GetAllAnnouncementAsync(predicate,"");
            var response = _mapper.Map<List<GetAllAnnouncementQueryResponse>>(announcements);

            return await OptResult<List<GetAllAnnouncementQueryResponse>>.SuccessAsync(response, Messages.Successfull);
        }
    }
}
