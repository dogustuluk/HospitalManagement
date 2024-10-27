namespace HospitalManagement.Application.Features.Commands.DbParameterType.CreateDbParameterType;

public class CreateDbParameterTypeCommandResponse
{
    public Guid Guid { get; set; }
    public string? DbParameterTypeName { get; set; }
}