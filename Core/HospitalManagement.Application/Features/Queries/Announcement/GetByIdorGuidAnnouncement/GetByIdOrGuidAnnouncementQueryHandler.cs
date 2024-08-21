using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;

namespace HospitalManagement.Application.Features.Queries.Announcement.GetByIdorGuidAnnouncement
{
    public class GetByIdOrGuidAnnouncementQueryHandler : IRequestHandler<GetByIdOrGuidAnnouncementQueryRequest, OptResult<GetByIdOrGuidAnnouncementQueryResponse>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public GetByIdOrGuidAnnouncementQueryHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByIdOrGuidAnnouncementQueryResponse>> Handle(GetByIdOrGuidAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                object value = null;
                if (request.Id != null) value = request.Id;
                if (request.guid != null) value = request.guid;
                var data = await _announcementService.GetByIdOrGuid(value);

                var mappedData = _mapper.Map<GetByIdOrGuidAnnouncementQueryResponse>(data.Data);
                if (mappedData == null) return await OptResult<GetByIdOrGuidAnnouncementQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetByIdOrGuidAnnouncementQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
