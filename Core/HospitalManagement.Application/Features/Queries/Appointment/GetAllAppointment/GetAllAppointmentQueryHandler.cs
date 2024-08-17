namespace HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment
{
    public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQueryRequest, OptResult<List<GetAllAppointmentQueryResponse>>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        private readonly AppointmentSpecifications _appointmentSpecifications;

        public GetAllAppointmentQueryHandler(IAppointmentService appointmentService, IMapper mapper, AppointmentSpecifications appointmentSpecifications)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _appointmentSpecifications = appointmentSpecifications;
        }

        public async Task<OptResult<List<GetAllAppointmentQueryResponse>>> Handle(GetAllAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var predicate = _appointmentSpecifications.GetAllPredicate(request);
                var appointments = await _appointmentService.GetAllAppointment(predicate, "");
                if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "NameSurname ASC";

                var dataList = _mapper.Map<List<GetAllAppointmentQueryResponse>>(appointments);
                return await OptResult<List<GetAllAppointmentQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
            });
        }
    }
}
