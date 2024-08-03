namespace HospitalManagement.Application.Features.Queries.Department.GetDataList
{
    public class GetDataListQueryRequest : IRequest<OptResult<List<GetDataListQueryResponse>>>
    {
        public string? SelectedText { get; set; }
    }
}