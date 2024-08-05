namespace HospitalManagement.Application.Features.Queries.Department.GetValue
{
    public class GetValueQueryRequest : IRequest<OptResult<GetValueQueryResponse>>
    {
        public string ColumnName { get; set; }
        public int DataId { get; set; }
    }
}