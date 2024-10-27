namespace HospitalManagement.Application.Features.Commands.DbParameterType.DeleteDbParameterType;

public class DeleteDbParameterTypeCommandRequest : IRequest<OptResult<DeleteDbParameterTypeCommandResponse>>
{
    public Guid Guid { get; set; }
}