namespace HospitalManagement.Application.Features.Commands.DbParameterType.CreateDbParameterType;
public class CreateDbParameterTypeCommandHandler : IRequestHandler<CreateDbParameterTypeCommandRequest, OptResult<CreateDbParameterTypeCommandResponse>>
{
    private readonly IDbParameterTypeService _dbParameterTypeService;
    private readonly IMapper _mapper;

    public CreateDbParameterTypeCommandHandler(IDbParameterTypeService dbParameterTypeService, IMapper mapper)
    {
        _dbParameterTypeService = dbParameterTypeService;
        _mapper = mapper;
    }

    public async Task<OptResult<CreateDbParameterTypeCommandResponse>> Handle(CreateDbParameterTypeCommandRequest request, CancellationToken cancellationToken)
    {
        return await ExceptionHandler.HandleOptResultAsync(async () =>
        {
            var mappedDto = _mapper.Map<Create_DBParameterType_Dto>(request);
            var data = await _dbParameterTypeService.CreateDbParameterTypeAsync(mappedDto);
            if (!data.Succeeded)
                return await OptResult<CreateDbParameterTypeCommandResponse>.FailureAsync(data.Messages);

            var response = _mapper.Map<CreateDbParameterTypeCommandResponse>(data.Data);
            return await OptResult<CreateDbParameterTypeCommandResponse>.SuccessAsync(response, Messages.SuccessfullyAdded);
        });
    }
}
