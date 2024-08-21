namespace HospitalManagement.Application.Features.Queries.Hospital.GetValueHospital
{
    public class GetValueHospitalQueryRequest : IRequest<OptResult<GetValueHospitalQueryResponse>>
    {
        public string ColumnName { get; set; }
        public int DataId { get; set; }
    }
}