namespace HospitalManagement.Application.Features.Queries.User.GetByUserIdOrGuidUser
{
    public class GetByIdOrGuidUserQueryRequest : IRequest<OptResult<GetByIdOrGuidUserQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? Guid { get; set; }
    }
}