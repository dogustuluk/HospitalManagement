using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;
using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment;
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
        [HttpGet]
        [Route("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments([FromQuery] GetAllAppointmentQueryRequest request)
        {
            OptResult<List<GetAllAppointmentQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdAppointment")]
        public async Task<IActionResult> GetByIdAppointment([FromQuery] GetByIdOrGuidAppointmentQueryRequest request)
        {
            OptResult<GetByIdOrGuidAppointmentQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetValueAppointment")]
        public async Task<IActionResult> GetValueAppointment([FromQuery] GetValueAppointmentQueryRequest request)
        {
            OptResult<GetValueAppointmentQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListAppointment")]
        public async Task<IActionResult> GetDataListAppointment([FromQuery] GetDataListAppointmentQueryRequest request)
        {
            OptResult<List<GetDataListAppointmentQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
