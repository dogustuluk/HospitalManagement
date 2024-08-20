using HospitalManagement.Application.Abstractions.Services.Appointment;
using HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment;

namespace HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital
{
    public class GetByIdOrGuidHospitalQueryHandler : IRequestHandler<GetByIdOrGuidHospitalQueryRequest, OptResult<GetByIdOrGuidHospitalQueryResponse>>
    {
        private readonly IHospitalService hospitalService;
        private readonly IMapper _mapper;

        public GetByIdOrGuidHospitalQueryHandler(IHospitalService hospitalService, IMapper mapper)
        {
            this.hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByIdOrGuidHospitalQueryResponse>> Handle(GetByIdOrGuidHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                object value = null;
                if (request.Id != null) value = request.Id;
                if (request.guid != null) value = request.guid;
                var data = await hospitalService.GetByIdOrGuid(value);

                var mappedData = _mapper.Map<GetByIdOrGuidHospitalQueryResponse>(data.Data);
                if(mappedData == null) return await OptResult<GetByIdOrGuidHospitalQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetByIdOrGuidHospitalQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
