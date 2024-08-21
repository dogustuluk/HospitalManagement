namespace HospitalManagement.Application.Features.Queries.Citiy.GetDataListCity
{
    public class GetDataListCityQueryRequest : IRequest<OptResult<List<GetDataListCityQueryResponse>>>
    {
        public string? SelectedText { get; set; }
    }
}