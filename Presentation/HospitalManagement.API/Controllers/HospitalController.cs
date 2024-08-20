using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Hospital.CreateHospital;
using HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital;
using HospitalManagement.Application.Features.Queries.Department.GetDataPagedList;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HospitalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateHospital")]
        public async Task<IActionResult> CreateHospital(CreateHospitalCommandRequest request)
        {
            OptResult<CreateHospitalCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateHospital")]
        public async Task<IActionResult> UpdateHospital(UpdateHospitalCommandRequest request)
        {
            OptResult<UpdateHospitalCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllHospital")]
        public async Task<IActionResult> GetAllHospital([FromQuery] GetAllHospitalQueryRequest request)
        {
            OptResult<List<GetAllHospitalQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdOrGuidHospital")]
        public async Task<IActionResult> GetByIdOrGuidHospital([FromQuery] GetByIdOrGuidHospitalQueryRequest request)
        {
            OptResult<GetByIdOrGuidHospitalQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListHospital")]
        public async Task<IActionResult> GetDataListHospital([FromQuery] GetDataListHospitalQueryRequest request)
        {
            OptResult<List<GetDataListHospitalQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedData")]
        public async Task<IActionResult> GetAllPagedData([FromQuery] GetAllPagedHospitalQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>> responsePaginatedData = await _mediator.Send(request);
            return Ok(responsePaginatedData);
        }
    }
}
