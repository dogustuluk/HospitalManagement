using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;

namespace HospitalManagement.Application.Features.Queries.Room.GetAllPagedRoom
{
    public class GetAllPagedRoomQueryHandler : IRequestHandler<GetAllPagedRoomQueryRequest, OptResult<PaginatedList<GetAllPagedRoomQueryResponse>>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public GetAllPagedRoomQueryHandler(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedRoomQueryResponse>>> Handle(GetAllPagedRoomQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPaged_Room_Index_Dto>(request);

                var result = await _roomService.GetAllPagedListAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedRoomQueryResponse>>(result.Data);

                if (result.Data == null) return await OptResult<PaginatedList<GetAllPagedRoomQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<PaginatedList<GetAllPagedRoomQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
