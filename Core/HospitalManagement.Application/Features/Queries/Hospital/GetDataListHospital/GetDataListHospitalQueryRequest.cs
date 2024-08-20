namespace HospitalManagement.Application.Features.Queries.Hospital.GetDataListHospital
{
    public class GetDataListHospitalQueryRequest : IRequest<OptResult<List<GetDataListHospitalQueryResponse>>>
    {
        public string? SelectedText { get; set; }
    }
}