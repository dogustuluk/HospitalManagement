using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Features.Queries.Citiy.GetDataListCity;

namespace HospitalManagement.Application.Features.Queries.Medicine.GetDataListMedicine
{
    public class GetDataListMedicineQueryHandler : IRequestHandler<GetDataListMedicineQueryRequest, OptResult<List<GetDataListMedicineQueryResponse>>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public GetDataListMedicineQueryHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<List<GetDataListMedicineQueryResponse>>> Handle(GetDataListMedicineQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var myCities = await _medicineService.GetDataListAsync();

                if (myCities == null) return await OptResult<List<GetDataListMedicineQueryResponse>>.FailureAsync(Messages.NullValue);

                var response = _mapper.Map<List<GetDataListMedicineQueryResponse>>(myCities);

                return await OptResult<List<GetDataListMedicineQueryResponse>>.SuccessAsync(response);
            });
        }
    }
}
