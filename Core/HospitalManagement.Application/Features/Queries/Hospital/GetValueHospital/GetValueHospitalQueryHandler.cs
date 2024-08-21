using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment;

namespace HospitalManagement.Application.Features.Queries.Hospital.GetValueHospital
{
    public class GetValueHospitalQueryHandler : IRequestHandler<GetValueHospitalQueryRequest, OptResult<GetValueHospitalQueryResponse>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;

        public GetValueHospitalQueryHandler(IHospitalService hospitalService, IMapper mapper)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueHospitalQueryResponse>> Handle(GetValueHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _hospitalService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueHospitalQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueHospitalQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueHospitalQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
