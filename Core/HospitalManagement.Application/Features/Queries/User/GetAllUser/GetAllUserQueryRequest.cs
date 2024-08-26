namespace HospitalManagement.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<OptResult<List<GetAllUserQueryResponse>>>
    {
        public int? UserType { get; set; }
        public string? OrderBy { get; set; } = "Id ASC";
    }
}