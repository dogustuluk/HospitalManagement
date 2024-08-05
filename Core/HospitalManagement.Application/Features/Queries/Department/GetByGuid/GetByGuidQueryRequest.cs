namespace HospitalManagement.Application.Features.Queries.Department.GetByGuid
{
    public class GetByGuidQueryRequest : IRequest<OptResult<GetByGuidQueryResponse>>
    {
        public Guid Guid { get; set; }
    }
}