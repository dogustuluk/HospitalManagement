using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommandRequest request)
        {
            OptResult<CreateAppointmentCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
