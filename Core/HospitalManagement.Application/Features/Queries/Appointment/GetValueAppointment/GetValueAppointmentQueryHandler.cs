using HospitalManagement.Application.Constants;

namespace HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment
{
    public class GetValueAppointmentQueryHandler : IRequestHandler<GetValueAppointmentQueryRequest, OptResult<GetValueAppointmentQueryResponse>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public GetValueAppointmentQueryHandler(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueAppointmentQueryResponse>> Handle(GetValueAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async() =>
            {
                var data = await _appointmentService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}",1);
                var mappedData = _mapper.Map<GetValueAppointmentQueryResponse>(data);
                if (data == null) 
                    return await OptResult<GetValueAppointmentQueryResponse>.FailureAsync(Messages.NullData);
                
                return await OptResult<GetValueAppointmentQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
