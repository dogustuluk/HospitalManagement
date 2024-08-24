using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital
{
    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommandRequest, OptResult<UpdateHospitalCommandResponse>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;

        public UpdateHospitalCommandHandler(IHospitalService hospitalService, IMapper mapper)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<UpdateHospitalCommandResponse>> Handle(UpdateHospitalCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var updateHospitalDto = _mapper.Map<UpdateHospital_Dto>(request);

                var updatedHospital = await _hospitalService.UpdateHospitalAsync(updateHospitalDto);
                
                if (!updatedHospital.Succeeded)
                    return await OptResult<UpdateHospitalCommandResponse>.FailureAsync(updatedHospital.Messages);
                
                var response = _mapper.Map<UpdateHospitalCommandResponse>(updatedHospital.Data);
                return await OptResult<UpdateHospitalCommandResponse>.SuccessAsync(response, Messages.SuccessfullyUpdated);
            });
        }
    }
}
