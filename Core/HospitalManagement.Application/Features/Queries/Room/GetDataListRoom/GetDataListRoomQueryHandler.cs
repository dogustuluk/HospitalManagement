using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Features.Queries.Room.GetDataListRoom
{
    public class GetDataListRoomQueryHandler : IRequestHandler<GetDataListXQueryRequest, OptResult<List<GetDataListXQueryResponse>>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public GetDataListRoomQueryHandler(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListXQueryResponse>>> Handle(GetDataListXQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myappointments = await _roomService.GetDataListAsync();

                if (myappointments == null) return await OptResult<List<GetDataListXQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListXQueryResponse>>(myappointments);

                return await OptResult<List<GetDataListXQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}
