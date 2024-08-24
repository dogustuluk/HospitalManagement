using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Features.Commands.Medicine.UpdateMedicine
{
    public class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommandRequest, OptResult<UpdateMedicineCommandResponse>>
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public UpdateMedicineCommandHandler(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        public async Task<OptResult<UpdateMedicineCommandResponse>> Handle(UpdateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var updateHospitalDto = _mapper.Map<Update_Medicine_Dto>(request);

                var updatedHospital = await _medicineService.UpdateMedicineAsync(updateHospitalDto);

                if (!updatedHospital.Succeeded)
                    return await OptResult<UpdateMedicineCommandResponse>.FailureAsync(updatedHospital.Messages);

                var response = _mapper.Map<UpdateMedicineCommandResponse>(updatedHospital.Data);
                return await OptResult<UpdateMedicineCommandResponse>.SuccessAsync(response, Messages.SuccessfullyUpdated);
            });
        }
    }
}
