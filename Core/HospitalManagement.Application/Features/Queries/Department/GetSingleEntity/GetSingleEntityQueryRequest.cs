namespace HospitalManagement.Application.Features.Queries.Department.GetSingleEntity
{
    public class GetSingleEntityQueryRequest : IRequest<OptResult<GetSingleEntityQueryResponse>>
    {
        public Dictionary<string, object> Filters { get; set; }

        public GetSingleEntityQueryRequest()
        {
            Filters = new Dictionary<string, object>();
        }
    }
}