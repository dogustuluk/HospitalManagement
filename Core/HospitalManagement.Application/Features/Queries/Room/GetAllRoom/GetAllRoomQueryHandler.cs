using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Application.Features.Queries.Room.GetAllRoom
{
    public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQueryRequest, OptResult<List<GetAllRoomQueryResponse>>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly RoomSpecifications _roomSpecifications;

        public GetAllRoomQueryHandler(IRoomService roomService, IMapper mapper, RoomSpecifications roomSpecifications)
        {
            _roomService = roomService;
            _mapper = mapper;
            _roomSpecifications = roomSpecifications;
        }

        public async Task<OptResult<List<GetAllRoomQueryResponse>>> Handle(GetAllRoomQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _roomSpecifications.GetAllPredicate(request);
            var hospitals = await _roomService.GetAllRoomAsync(predicate, "");

            if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "Id ASC";

            var dataList = _mapper.Map<List<GetAllRoomQueryResponse>>(hospitals);

            return await OptResult<List<GetAllRoomQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
        }
    }
}
