using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;

namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine
{
    public class GetAllPagedMedicineQueryHandler : IRequestHandler<GetAllPagedMedicineQueryRequest, OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public GetAllPagedMedicineQueryHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>>> Handle(GetAllPagedMedicineQueryRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var model = _mapper.Map<GetAllPaged_Medicine_Index_Dto>(request);

                var result = await _medicineService.GetAllPagedListAsync(model);
                var response = _mapper.Map<PaginatedList<GetAllPagedMedicineQueryResponse>>(result.Data);

                if (result == null) return await OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>>.FailureAsync(Messages.UnSuccessfull);

                return await OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>>.SuccessAsync(response, Messages.Successfull);
            });
        }
    }
}
