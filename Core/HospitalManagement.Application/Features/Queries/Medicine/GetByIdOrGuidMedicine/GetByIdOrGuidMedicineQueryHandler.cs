using HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital;

namespace HospitalManagement.Application.Features.Queries.Medicine.GetByIdOrGuidMedicine
{
    public class GetByIdOrGuidMedicineQueryHandler : IRequestHandler<GetByIdOrGuidMedicineQueryRequest, OptResult<GetByIdOrGuidMedicineQueryResponse>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public GetByIdOrGuidMedicineQueryHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetByIdOrGuidMedicineQueryResponse>> Handle(GetByIdOrGuidMedicineQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                object value = null;
                if (request.Id != null) value = request.Id;
                if (request.guid != null) value = request.guid;
                var data = await _medicineService.GetByIdOrGuid(value);

                var mappedData = _mapper.Map<GetByIdOrGuidMedicineQueryResponse>(data.Data);
                if (mappedData == null) return await OptResult<GetByIdOrGuidMedicineQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetByIdOrGuidMedicineQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
