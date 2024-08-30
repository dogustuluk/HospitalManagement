using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Queries.DbParameter.GetAllDbParameter;
using HospitalManagement.Application.Features.Queries.DbParameter.GetAllPagedDbParameter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbParameterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DbParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpPost]
        //[Route("CreateDbParameter")]
        //public async Task<IActionResult> CreateDbParameter(CreateDbParameterCommandRequest request)
        //{
        //    OptResult<CreateDbParameterCommandResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        //[HttpPut]
        //[Route("UpdateDbParameter")]
        //public async Task<IActionResult> UpdateDbParameter(UpdateDbParameterCommandRequest request)
        //{
        //    OptResult<UpdateDbParameterCommandResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        [HttpGet]
        [Route("GetAllDbParameter")]
        public async Task<IActionResult> GetAllDbParameter([FromQuery] GetAllDbParameterQueryRequest request)
        {
            OptResult<List<GetAllDbParameterQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedData")]
        public async Task<IActionResult> GetAllPagedData([FromQuery] GetAllPagedDbParameterQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedDbParameterQueryResponse>> responsePaginatedData = await _mediator.Send(request);
            return Ok(responsePaginatedData);
        }
        //[HttpGet]
        //[Route("GetByIdOrGuidDbParameter")]
        //public async Task<IActionResult> GetByIdOrGuidDbParameter([FromQuery] GetByIdOrGuidDbParameterQueryRequest request)
        //{
        //    OptResult<GetByIdOrGuidDbParameterQueryResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        //[HttpGet]
        //[Route("GetDataListDbParameter")]
        //public async Task<IActionResult> GetDataListDbParameter([FromQuery] GetDataListXQueryRequest request)
        //{
        //    OptResult<List<GetDataListXQueryResponse>> response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet]
        //[Route("GetValueDbParameter")]
        //public async Task<IActionResult> GetValueDbParameter([FromQuery] GetValueXQueryRequest request)
        //{
        //    OptResult<GetValueXQueryResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
