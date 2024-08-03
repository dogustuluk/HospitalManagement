namespace HospitalManagement.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, OptResult<CreateDepartmentCommandResponse>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;


        public CreateDepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateDepartmentCommandResponse>> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                {
                    var createDepartmentDto = _mapper.Map<Create_Department_Dto>(request);

                    var newDepartment = await _departmentService.CreateDepartment(createDepartmentDto);

                    var response = new CreateDepartmentCommandResponse
                    {
                        DepartmentName = request.DepartmentName,
                        DepartmentCode = request.DepartmentCode,
                        SortOrderNo = request.SortOrderNo.ToString()
                    };
                    return OptResult<CreateDepartmentCommandResponse>.Success(response, Messages.SuccessfullyAdded);
                }
            });
        }
    }
}
