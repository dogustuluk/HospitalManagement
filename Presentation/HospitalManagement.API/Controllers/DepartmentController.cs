using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Application.Features.Queries.Department.GetByEntity;
using HospitalManagement.Application.Features.Queries.Department.GetByGuid;
using HospitalManagement.Application.Features.Queries.Department.GetById;
using HospitalManagement.Application.Features.Queries.Department.GetDataList;
using HospitalManagement.Application.Features.Queries.Department.GetDataPagedList;
using HospitalManagement.Application.Features.Queries.Department.GetSingleEntity;
using HospitalManagement.Application.Features.Queries.Department.GetValue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/management/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllDepartment")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentQueryRequest request)
        {
            OptResult<IQueryable<GetAllDepartmentQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataList")]
        public async Task<IActionResult> GetDataList([FromQuery] GetDataListQueryRequest request)
        {
            OptResult<List<GetDataListQueryResponse>> responseDataList = await _mediator.Send(request);
            if (!string.IsNullOrEmpty(request.SelectedText))
                responseDataList.Data.Insert(0, new GetDataListQueryResponse() { Id = "0", Guid = "", Name = request.SelectedText });

            return Ok(responseDataList);
        }
        [HttpGet]
        [Route("GetAllPagedData")]
        public async Task<IActionResult> GetAllPagedData([FromQuery] GetDataPagedListQueryRequest request)
        {
            OptResult<PaginatedList<GetDataPagedListQueryResponse>> responsePaginatedData = await _mediator.Send(request);
            return Ok(responsePaginatedData);
        }
        [HttpPost]
        [Route("GetSingleEntity")]
        public async Task<IActionResult> GetSingleEntity([FromBody] GetSingleEntityQueryRequest request)
        {
            OptResult<GetSingleEntityQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("GetByEntityWithProperties")]
        public async Task<IActionResult> GetByEntity([FromBody] GetByEntityQueryRequest request)
        {
            OptResult<GetByEntityQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdQueryRequest request)
        {
            OptResult<GetByIdQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByGuid")]
        public async Task<IActionResult> GetByGuid([FromQuery] GetByGuidQueryRequest request)
        {
            OptResult<GetByGuidQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetValue")]
        public async Task<IActionResult> GetValue([FromQuery] GetValueQueryRequest request)
        {
            OptResult<GetValueQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateDepartment")]
        public async Task<IActionResult> Create(CreateDepartmentCommandRequest request)
        {
            OptResult<CreateDepartmentCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
