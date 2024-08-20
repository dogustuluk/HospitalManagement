using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Appointment.GetDataPagedListAppointment;

namespace HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital
{
    public class GetAllPagedHospitalQueryHandler : IRequestHandler<GetAllPagedHospitalQueryRequest, OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;

        public GetAllPagedHospitalQueryHandler(IHospitalService hospitalService, IMapper mapper)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>>> Handle(GetAllPagedHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPagedHospital_Index_Dto>(request);

                var result = await _hospitalService.GetAllPagedListAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedHospitalQueryResponse>>(result.Data);

                if (result == null) return await OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
