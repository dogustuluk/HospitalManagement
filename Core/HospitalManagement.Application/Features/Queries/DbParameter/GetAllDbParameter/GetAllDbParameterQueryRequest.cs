namespace HospitalManagement.Application.Features.Queries.DbParameter.GetAllDbParameter
{
    public class GetAllDbParameterQueryRequest : IRequest<OptResult<List<GetAllDbParameterQueryResponse>>>
    {
        public string? OrderBy { get; set; } = "Id ASC";
    }
}