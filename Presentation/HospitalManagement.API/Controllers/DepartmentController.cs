using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Application.GenericObjects;
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

        [HttpPost]
        [Route("GetAllDepartment")]
        public async Task<IActionResult> GetAll(GetAllDepartmentQueryRequest request)
        {
            List<OptResult<GetAllDepartmentQueryResponse>> response = await _mediator.Send(request);
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
