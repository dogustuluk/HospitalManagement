using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Medicine.CreateMedicine;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateMedicine")]
        public async Task<IActionResult> CreateMedicine(CreateMedicineCommandRequest request)
        {
            OptResult<CreateMedicineCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
