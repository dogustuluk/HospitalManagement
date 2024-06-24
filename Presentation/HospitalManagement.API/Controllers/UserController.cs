using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.GenericObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
