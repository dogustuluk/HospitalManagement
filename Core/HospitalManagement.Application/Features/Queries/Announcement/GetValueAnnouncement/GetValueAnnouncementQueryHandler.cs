using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Features.Queries.Announcement.GetValueAnnouncement
{
    public class GetValueAnnouncementQueryHandler : IRequestHandler<GetValueAnnouncementQueryRequest, OptResult<GetValueAnnouncementQueryResponse>>
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public GetValueAnnouncementQueryHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueAnnouncementQueryResponse>> Handle(GetValueAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _announcementService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueAnnouncementQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueAnnouncementQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueAnnouncementQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
