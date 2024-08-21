using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Queries.Citiy.GetDataListCity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetDataListCity")]
        public async Task<IActionResult> GetDataListCity([FromQuery] GetDataListCityQueryRequest request)
        {
            OptResult<List<GetDataListCityQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
