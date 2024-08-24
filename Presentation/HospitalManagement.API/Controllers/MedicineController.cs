using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital;
using HospitalManagement.Application.Features.Commands.Medicine.CreateMedicine;
using HospitalManagement.Application.Features.Commands.Medicine.UpdateMedicine;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetValueHospital;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetByIdOrGuidMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetDataListMedicine;
using HospitalManagement.Application.Features.Queries.Medicine.GetMedicineDetail;
using HospitalManagement.Application.Features.Queries.Medicine.GetValueMedicine;
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
        [HttpPut]
        [Route("UpdateMedicine")]
        public async Task<IActionResult> UpdateHospital(UpdateMedicineCommandRequest request)
        {
            OptResult<UpdateMedicineCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedMedicine")]
        public async Task<IActionResult> GetAllPagedAnnouncement([FromQuery] GetAllPagedMedicineQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        //[HttpPut]
        //[Route("UpdateMedicine")]
        //public async Task<IActionResult> UpdateMedicine(UpdateMedicineCommandRequest request)
        //{
        //    OptResult<UpdateMedicineCommandResponse> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
        [HttpGet]
        [Route("GetAllMedicine")]
        public async Task<IActionResult> GetAllMedicine([FromQuery] GetAllMedicineQueryRequest request)
        {
            OptResult<List<GetAllMedicineQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdOrGuidMedicine")]
        public async Task<IActionResult> GetByIdOrGuidMedicine([FromQuery] GetByIdOrGuidMedicineQueryRequest request)
        {
            OptResult<GetByIdOrGuidMedicineQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetDataListMedicine")]
        public async Task<IActionResult> GetDataListMedicine([FromQuery] GetDataListMedicineQueryRequest request)
        {
            OptResult<List<GetDataListMedicineQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetValueMedicine")]
        public async Task<IActionResult> GetValueMedicine([FromQuery] GetValueMedicineQueryRequest request)
        {
            OptResult<GetValueMedicineQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetMedicineDetail")]
        public async Task<IActionResult> GetMedicineDetail([FromQuery] GetMedicineDetailQueryRequest request)
        {
            OptResult<GetMedicineDetailQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
