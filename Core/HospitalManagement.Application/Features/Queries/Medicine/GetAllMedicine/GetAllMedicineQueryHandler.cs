using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.Specifications;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine
{
    public class GetAllMedicineQueryHandler : IRequestHandler<GetAllMedicineQueryRequest, OptResult<List<GetAllMedicineQueryResponse>>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        private readonly MedicineSpecifications _medicineSpecifications;

        public GetAllMedicineQueryHandler(IMedicineService medicineService, IMapper mapper, MedicineSpecifications medicineSpecifications)
        {
            _medicineService = medicineService;
            _mapper = mapper;
            _medicineSpecifications = medicineSpecifications;
        }

        public async Task<OptResult<List<GetAllMedicineQueryResponse>>> Handle(GetAllMedicineQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _medicineSpecifications.GetAllPredicate(request);
            var hospitals = await _medicineService.GetAllMedicine(predicate, "");

            if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "Name ASC";

            var dataList = _mapper.Map<List<GetAllMedicineQueryResponse>>(hospitals);

            return await OptResult<List<GetAllMedicineQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
        }
    }
}
