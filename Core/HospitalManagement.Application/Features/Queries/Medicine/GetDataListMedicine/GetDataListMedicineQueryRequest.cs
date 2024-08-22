namespace HospitalManagement.Application.Features.Queries.Medicine.GetDataListMedicine
{
    public class GetDataListMedicineQueryRequest : IRequest<OptResult<List<GetDataListMedicineQueryResponse>>>
    {
        public string? SelectedText { get; set; }
    }
}