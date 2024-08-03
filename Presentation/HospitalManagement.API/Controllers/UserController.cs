using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.Features.Commands.User.AppUser.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/auth/[controller]")]
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
    }
}
