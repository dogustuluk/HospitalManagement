using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Commands.Appointment.CreateAppointment;

namespace HospitalManagement.Application.Features.Commands.Hospital.CreateHospital
{
    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommandRequest, OptResult<CreateHospitalCommandResponse>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IMapper _mapper;

        public CreateHospitalCommandHandler(IHospitalService hospitalService, IMapper mapper)
        {
            _hospitalService = hospitalService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateHospitalCommandResponse>> Handle(CreateHospitalCommandRequest request, CancellationToken cancellationToken)
        {
           // OptResult<CreateHospitalCommandResponse> response = new OptResult<CreateHospitalCommandResponse>();

            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var createHospitalDto = _mapper.Map<CreateHospital_Dto>(request);
                var data = await _hospitalService.CreateHospitalAsync(createHospitalDto);
                if (data.Succeeded)
                {
                    var response = _mapper.Map<CreateHospitalCommandResponse>(data.Data);
                    return await OptResult<CreateHospitalCommandResponse>.SuccessAsync(response, Messages.SuccessfullyAdded);
                }

                return await OptResult<CreateHospitalCommandResponse>.FailureAsync(data.Messages);
            });
        }
    }
}
