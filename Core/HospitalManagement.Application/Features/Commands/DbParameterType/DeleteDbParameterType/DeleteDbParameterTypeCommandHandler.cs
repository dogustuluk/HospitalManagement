namespace HospitalManagement.Application.Features.Commands.DbParameterType.DeleteDbParameterType;
public class DeleteDbParameterTypeCommandHandler : IRequestHandler<DeleteDbParameterTypeCommandRequest, OptResult<DeleteDbParameterTypeCommandResponse>>
{
    private readonly IDbParameterTypeService _dbParameterTypeService;
    private readonly IMapper _mapper;

    public DeleteDbParameterTypeCommandHandler(IDbParameterTypeService dbParameterTypeService, IMapper mapper)
    {
        _dbParameterTypeService = dbParameterTypeService;
        _mapper = mapper;
    }

    public async Task<OptResult<DeleteDbParameterTypeCommandResponse>> Handle(DeleteDbParameterTypeCommandRequest request, CancellationToken cancellationToken)
    {
        return await ExceptionHandler.HandleOptResultAsync(async () =>
        {
            var data = await _dbParameterTypeService.DeleteDbParameterTypeAsync(request.Guid, 1);
            var mappedData = _mapper.Map<DeleteDbParameterTypeCommandResponse>(data.Data);
            if (mappedData == null) return await OptResult<DeleteDbParameterTypeCommandResponse>.FailureAsync(Messages.NullData);
            return await OptResult<DeleteDbParameterTypeCommandResponse>.SuccessAsync(mappedData, Messages.SuccessfullyDeleted);
        });
    }
}
