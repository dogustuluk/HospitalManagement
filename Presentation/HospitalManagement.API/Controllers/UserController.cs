using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement;
using HospitalManagement.Application.Features.Queries.User.GetAllPagedUser;
using HospitalManagement.Application.Features.Queries.User.GetAllUser;
using HospitalManagement.Application.Features.Queries.User.GetByUserIdOrGuidUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            OptResult<CreateUserCommandResponse> response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest updateUserCommandRequest)
        {
            OptResult<UpdateUserCommandResponse> response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedUser")]
        public async Task<IActionResult> GetAllPagedUser([FromQuery] GetAllPagedUserQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedUserQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserQueryRequest request)
        {
            OptResult<List<GetAllUserQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetValueUser")]
        public async Task<IActionResult> GetValueUser([FromQuery] GetValueXQueryRequest request)
        {
            OptResult<GetValueXQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdOrGuidUser")]
        public async Task<IActionResult> GetByIdOrGuidUser([FromQuery] GetByIdOrGuidUserQueryRequest request)
        {
            OptResult<GetByIdOrGuidUserQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListUser")]
        public async Task<IActionResult> GetDataListUser([FromQuery] GetDataListXQueryRequest request)
        {
            OptResult<List<GetDataListXQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
