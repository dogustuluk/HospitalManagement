using HospitalManagement.Application.Common.DTOs._0RequestResponse;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.DbParameterType.CreateDbParameterType;
using HospitalManagement.Application.Features.Commands.DbParameterType.DeleteDbParameterType;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetAllDbParameterType;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetAllPagedDbParameterType;
using HospitalManagement.Application.Features.Queries.DbParameterType.GetByIdOrGuidDbParameterType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DbParameterTypeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbParameterTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DbParameterTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateDbParameterType")]
        public async Task<IActionResult> CreateDbParameterType(CreateDbParameterTypeCommandRequest request)
        {
            OptResult<CreateDbParameterTypeCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        //[HttpPut]
        //[Route("UpdateDbParameterType")]
        //public async Task<IActionResult> UpdateDbParameterType(UpdateDbParameterTypeCommandRequest request)
        //{
        //    OptResult<UpdateDbParameterTypeCommandResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        [HttpDelete]
        [Route("DeleteDbParameterType")]
        public async Task<IActionResult> DeleteDbParameterType(DeleteDbParameterTypeCommandRequest request)
        {
            OptResult<DeleteDbParameterTypeCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllDbParameterType")]
        public async Task<IActionResult> GetAllDbParameterType([FromQuery] GetAllDbParameterTypeQueryRequest request)
        {
            OptResult<List<GetAllDbParameterTypeQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedData")]
        public async Task<IActionResult> GetAllPagedData([FromQuery] GetAllPagedDbParameterTypeQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedDbParameterTypeQueryResponse>> responsePaginatedData = await _mediator.Send(request);
            return Ok(responsePaginatedData);
        }
        [HttpGet]
        [Route("GetByIdOrGuidDbParameterType")]
        public async Task<IActionResult> GetByIdOrGuidDbParameterType([FromQuery] GetByIdOrGuidDbParameterTypeQueryRequest request)
        {
            OptResult<GetByIdOrGuidDbParameterTypeQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListDbParameterType")]
        public async Task<IActionResult> GetDataListDbParameterType([FromQuery] GetDataListXQueryRequest request)
        {
            OptResult<List<GetDataListXQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetValueDbParameterType")]
        public async Task<IActionResult> GetValueDbParameterType([FromQuery] GetValueXQueryRequest request)
        {
            OptResult<GetValueXQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
