using HospitalManagement.Application.Common.DTOs.Appointment;

namespace HospitalManagement.Application.Features.Queries.Appointment.GetDataPagedListAppointment
{
    public class GetDataPagedListAppointmentQueryHandler : IRequestHandler<GetDataPagedListAppointmentQueryRequest, OptResult<PaginatedList<GetDataPagedListAppointmentQueryResponse>>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        private readonly AppointmentSpecifications _appointmentSpecifications;

        public GetDataPagedListAppointmentQueryHandler(IAppointmentService appointmentService, IMapper mapper, AppointmentSpecifications appointmentSpecifications)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _appointmentSpecifications = appointmentSpecifications;
        }

        public async Task<OptResult<PaginatedList<GetDataPagedListAppointmentQueryResponse>>> Handle(GetDataPagedListAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPagedAppointment_Index_Dto>(request);

                var result = await _appointmentService.GetAllPagedListAsync(model);

                return await OptResult<PaginatedList<GetDataPagedListAppointmentQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

            });
        }
    }
}
