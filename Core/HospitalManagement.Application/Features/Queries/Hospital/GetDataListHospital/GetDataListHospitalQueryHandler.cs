using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment;

namespace HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital
{
    public class GetDataListHospitalQueryHandler : IRequestHandler<GetDataListHospitalQueryRequest, OptResult<List<GetDataListHospitalQueryResponse>>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;

        public GetDataListHospitalQueryHandler(IHospitalService hospitalService, IMapper mapper)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListHospitalQueryResponse>>> Handle(GetDataListHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myappointments = await _hospitalService.GetDataListAsync();

                if (myappointments == null) return await OptResult<List<GetDataListHospitalQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListHospitalQueryResponse>>(myappointments);

                return await OptResult<List<GetDataListHospitalQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}