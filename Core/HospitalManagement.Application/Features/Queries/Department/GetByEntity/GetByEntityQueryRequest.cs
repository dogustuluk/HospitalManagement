namespace HospitalManagement.Application.Features.Queries.Department.GetByEntity
{
    public class GetByEntityQueryRequest : IRequest<OptResult<GetByEntityQueryResponse>>
    {
        public object Value { get; set; }
        public string FieldName { get; set; }
    }
}