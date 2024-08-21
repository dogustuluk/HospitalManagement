using HospitalManagement.Application.Features.Commands.Announcement.UpdateAnnouncement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Features.Commands.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, OptResult<UpdateDepartmentCommandResponse>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<UpdateDepartmentCommandResponse>> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var mappedDto = _mapper.Map<Update_Department_Dto>(request);
                var updatedDepartment = await _departmentService.UpdateDepartmentAsync(mappedDto);
                if (!updatedDepartment.Succeeded)
                    return await OptResult<UpdateDepartmentCommandResponse>.FailureAsync(Messages.UnSuccessfull);

                var response = _mapper.Map<UpdateDepartmentCommandResponse>(updatedDepartment.Data);
                return await OptResult<UpdateDepartmentCommandResponse>.SuccessAsync(response, Messages.SuccessfullyUpdated);
            });
        }
    }
}
