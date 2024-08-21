using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;

namespace HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement
{
    public class GetAllPagedAnnouncementQueryHandler : IRequestHandler<GetAllPagedAnnouncementQueryRequest, OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public GetAllPagedAnnouncementQueryHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>>> Handle(GetAllPagedAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<GetAllPaged_Announcement_Dto>(request);
                var pagedData = await _announcementService.GetAllPagedAnnouncementAsync(mappedDto);
                var response = _mapper.Map<PaginatedList<GetAllPagedAnnouncementQueryResponse>>(pagedData.Data);

                if (pagedData == null) 
                    return await OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
