namespace HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment
{
    public class GetByIdOrGuidAppointmentQueryHandler : IRequestHandler<GetByIdOrGuidAppointmentQueryRequest, OptResult<GetByIdOrGuidAppointmentQueryResponse>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public GetByIdOrGuidAppointmentQueryHandler(IMapper mapper, IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        public async Task<OptResult<GetByIdOrGuidAppointmentQueryResponse>> Handle(GetByIdOrGuidAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                object value = null;
                if (request.Id != null) value = request.Id; 
                if (request.guid != null) value = request.guid; 
                var data = await _appointmentService.GetByIdOrGuid(value);

                var mappedData = _mapper.Map<GetByIdOrGuidAppointmentQueryResponse>(data.Data);
                mappedData.SpecificAppointmentResponse = data.Data switch
                {
                    VisitorAppointment => _mapper.Map<GetByIdOrGuidVisitorAppointmentResponse>(data.Data),
                    ExaminationAppointment => _mapper.Map<GetByIdOrGuidExaminationAppointmentResponse>(data.Data),
                    _ => null
                };
                return await OptResult<GetByIdOrGuidAppointmentQueryResponse>.SuccessAsync(mappedData);
            });
        }
    }
}
