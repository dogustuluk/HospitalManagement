using HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment;
using HospitalManagement.Domain.Entities.Appointment;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital
{
    public class GetAllHospitalQueryHandler : IRequestHandler<GetAllHospitalQueryRequest, OptResult<List<GetAllHospitalQueryResponse>>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;
        private readonly HospitalSpecifications _hospitalSpecifications;
        public GetAllHospitalQueryHandler(IHospitalService hospitalService, IMapper mapper, HospitalSpecifications hospitalSpecifications)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
            _hospitalSpecifications = hospitalSpecifications;
        }

        public async Task<OptResult<List<GetAllHospitalQueryResponse>>> Handle(GetAllHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            var predicate = _hospitalSpecifications.GetAllPredicate(request);
            var hospitals = await _hospitalService.GetAllHospital(predicate, "");
            
            if (string.IsNullOrEmpty(request.OrderBy)) request.OrderBy = "HospitalName ASC";
            
            var dataList = _mapper.Map<List<GetAllHospitalQueryResponse>>(hospitals);
            
            return await OptResult<List<GetAllHospitalQueryResponse>>.SuccessAsync(dataList, Messages.Successfull);
        }
    }
}
