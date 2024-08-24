using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Error.AddError;
using HospitalManagement.Application.Features.Queries.Error.GetAllPagedError;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ErrorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddError")]
        public async Task<IActionResult> AddError(AddErrorCommandRequest request)
        {
            OptResult<AddErrorCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedError")]
        public async Task<IActionResult> GetAllPagedError([FromQuery] GetAllPagedErrorQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedErrorQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
