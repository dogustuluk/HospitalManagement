using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Application.Features.Queries.Department.GetDataList;
using HospitalManagement.Application.GenericObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<IActionResult> GetAll([FromQuery]GetAllDepartmentQueryRequest request)
        {
            OptResult<IQueryable<GetAllDepartmentQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataList")]
        public async Task<IActionResult> GetDataList([FromQuery]GetDataListQueryRequest request)
        {
            OptResult<List<GetDataListQueryResponse>> responseDataList = await _mediator.Send(request);
            //if (!string.IsNullOrEmpty(request.SelectedText))
            //{
            //    responseDataList.Data.Insert(0, new DataList1() { Id = "0", Guid = "", Name = request.SelectedText });
            //}

            return Ok(responseDataList);
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
