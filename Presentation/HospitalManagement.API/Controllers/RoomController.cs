using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Room.CreateRoom;
using HospitalManagement.Application.Features.Queries.Room.GetAllPagedRoom;
using HospitalManagement.Application.Features.Queries.Room.GetAllRoom;
using HospitalManagement.Application.Features.Queries.Room.GetByIdOrGuidRoom;
using HospitalManagement.Application.Features.Queries.Room.GetRoomAvailability;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RoomManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom(CreateRoomCommandRequest request)
        {
            OptResult<CreateRoomCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        //[HttpPut]
        //[Route("UpdateRoom")]
        //public async Task<IActionResult> UpdateRoom(UpdateRoomCommandRequest request)
        //{
        //    OptResult<UpdateRoomCommandResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        [HttpGet]
        [Route("GetAllPagedData")]
        public async Task<IActionResult> GetAllPagedData([FromQuery] GetAllPagedRoomQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedRoomQueryResponse>> responsePaginatedData = await _mediator.Send(request);
            return Ok(responsePaginatedData);
        }
        [HttpGet]
        [Route("GetAllRoom")]
        public async Task<IActionResult> GetAllRoom([FromQuery] GetAllRoomQueryRequest request)
        {
            OptResult<List<GetAllRoomQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdOrGuidRoom")]
        public async Task<IActionResult> GetByIdOrGuidRoom([FromQuery] GetByIdOrGuidRoomQueryRequest request)
        {
            OptResult<GetByIdOrGuidRoomQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListRoom")]
        public async Task<IActionResult> GetDataListRoom([FromQuery] GetDataListXQueryRequest request)
        {
            OptResult<List<GetDataListXQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetValueRoom")]
        public async Task<IActionResult> GetValueRoom([FromQuery] GetValueXQueryRequest request)
        {
            OptResult<GetValueXQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetRoomAvailability")]
        public async Task<IActionResult> GetRoomAvailability([FromQuery] GetRoomAvailabilityQueryRequest request)
        {
            OptResult<GetRoomAvailabilityQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
