namespace HospitalManagement.Application.Features.Queries.Medicine.GetValueMedicine
{
    public class GetValueMedicineQueryHandler : IRequestHandler<GetValueMedicineQueryRequest, OptResult<GetValueMedicineQueryResponse>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public GetValueMedicineQueryHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetValueMedicineQueryResponse>> Handle(GetValueMedicineQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var data = await _medicineService.GetValue("", request.ColumnName, $"\"Id\" = {request.DataId}", 1);
                var mappedData = _mapper.Map<GetValueMedicineQueryResponse>(data);
                if (data == null)
                    return await OptResult<GetValueMedicineQueryResponse>.FailureAsync(Messages.NullData);

                return await OptResult<GetValueMedicineQueryResponse>.SuccessAsync(mappedData, Messages.Successfull);
            });
        }
    }
}
