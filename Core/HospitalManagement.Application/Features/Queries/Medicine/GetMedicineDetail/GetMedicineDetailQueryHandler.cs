namespace HospitalManagement.Application.Features.Queries.Medicine.GetMedicineDetail
{
    public class GetMedicineDetailQueryHandler : IRequestHandler<GetMedicineDetailQueryRequest, OptResult<GetMedicineDetailQueryResponse>>
    {
        private readonly IMedicineDetailService _medicineDetailService;
        private readonly IMapper _mapper;

        public GetMedicineDetailQueryHandler(IMedicineDetailService medicineDetailService, IMapper mapper)
        {
            _medicineDetailService = medicineDetailService;
            _mapper = mapper;
        }

        public async Task<OptResult<GetMedicineDetailQueryResponse>> Handle(GetMedicineDetailQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myData = await _medicineDetailService.GetMedicineDetail(request.Id);
                if (!myData.Succeeded)
                    return await OptResult<GetMedicineDetailQueryResponse>.FailureAsync(Messages.UnSuccessfull);

                var mappedData = _mapper.Map<GetMedicineDetailQueryResponse>(myData.Data);
                return await OptResult<GetMedicineDetailQueryResponse>.SuccessAsync(mappedData,Messages.Successfull);
            });
        }
    }
}
