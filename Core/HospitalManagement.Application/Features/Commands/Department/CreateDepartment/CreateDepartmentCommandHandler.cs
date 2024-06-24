using HospitalManagement.Application.Abstractions.Services.Management;
using HospitalManagement.Application.Constants;
using HospitalManagement.Application.GenericObjects;
using MediatR;

namespace HospitalManagement.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, OptResult<CreateDepartmentCommandResponse>>
    {
        private readonly IDepartmentService _departmentService;

        public CreateDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<OptResult<CreateDepartmentCommandResponse>> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _departmentService.CreateDepartment(new DTOs.Management.Create_Department_Dto
                {
                    DepartmentCode = request.DepartmentCode,
                    DepartmentName = request.DepartmentName,
                    isActive = request.isActive,
                    ManagerMemberId = request.ManagerMemberId,
                    Param1 = request.Param1,
                    Param2 = request.Param2,
                    ParentId = request.ParentId,
                    SortOrderNo = request.SortOrderNo
                });

                var response = new CreateDepartmentCommandResponse
                {
                    DepartmentName = request.DepartmentName,
                    DepartmentCode = request.DepartmentCode,
                    SortOrderNo = request.SortOrderNo.ToString()
                };
                return OptResult<CreateDepartmentCommandResponse>.Success(response, Messages.SuccessfullyAdded);
            }
            catch (Exception ex)
            {
                return OptResult<CreateDepartmentCommandResponse>.Failure(ex.Message);

            }
        }
    }
}
