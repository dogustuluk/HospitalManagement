using HospitalManagement.Domain.Entities.Management;

namespace HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment
{
    public class GetDataListAppointmentQueryHandler : IRequestHandler<GetDataListAppointmentQueryRequest, OptResult<List<GetDataListAppointmentQueryResponse>>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public GetDataListAppointmentQueryHandler(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListAppointmentQueryResponse>>> Handle(GetDataListAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myappointments = await _appointmentService.GetDataListAsync();

                if (myappointments == null) return await OptResult<List<GetDataListAppointmentQueryResponse>>.FailureAsync(Messages.NullValue);
                
                var response = _mapper.Map<List<GetDataListAppointmentQueryResponse>>(myappointments);
                
                return await OptResult<List<GetDataListAppointmentQueryResponse>>.SuccessAsync(response);

            });
        }
    }
}
