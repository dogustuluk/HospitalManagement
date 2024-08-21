using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Commands.Announcement.CrearteAnnouncement;
using HospitalManagement.Application.Features.Commands.Announcement.UpdateAnnouncement;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllAnnouncement;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllPagedAnnouncement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnnouncementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateAnnouncement")]
        public async Task<IActionResult> CreateAnnouncement(CreateAnnouncementCommandRequest request)
        {
            OptResult<CreateAnnouncementCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateAnnouncement")]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementCommandRequest request)
        {
            OptResult<UpdateAnnouncementCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllAnnouncement")]
        public async Task<IActionResult> GetAllHospital([FromQuery] GetAllAnnouncementQueryRequest request)
        {
            OptResult<List<GetAllAnnouncementQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAllPagedAnnouncement")]
        public async Task<IActionResult> GetAllPagedAnnouncement([FromQuery]GetAllPagedAnnouncementQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedAnnouncementQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
