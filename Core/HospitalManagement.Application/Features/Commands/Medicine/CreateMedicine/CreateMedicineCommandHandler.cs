using HospitalManagement.Application.Common.DTOs.Medical;

namespace HospitalManagement.Application.Features.Commands.Medicine.CreateMedicine
{
    public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommandRequest, OptResult<CreateMedicineCommandResponse>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public CreateMedicineCommandHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateMedicineCommandResponse>> Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<Create_Medicine_Dto>(request);
                var createdMedicine = await _medicineService.CreateMedicineAsync(mappedDto);
                if (createdMedicine == null)
                    return await OptResult<CreateMedicineCommandResponse>.FailureAsync(Messages.NullValue);
                var mappedData = _mapper.Map<CreateMedicineCommandResponse>(createdMedicine.Data);
                return await OptResult<CreateMedicineCommandResponse>.SuccessAsync(mappedData);
            });
        }
    }
}
