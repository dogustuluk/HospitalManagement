using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Features.Commands.Room.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommandRequest, OptResult<CreateRoomCommandResponse>>
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public CreateRoomCommandHandler(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateRoomCommandResponse>> Handle(CreateRoomCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<Create_Room_Dto>(request);
                var data = await _roomService.CreateRoomAsync(mappedDto);
                if (!data.Succeeded)
                    return await OptResult<CreateRoomCommandResponse>.FailureAsync(data.Messages);

                var response = _mapper.Map<CreateRoomCommandResponse>(data.Data);
                response.Beds = _mapper.Map<List<BedResponse>>(data.Data.Beds);

                return await OptResult<CreateRoomCommandResponse>.SuccessAsync(response, Messages.SuccessfullyAdded);
            });
        }
    }
}