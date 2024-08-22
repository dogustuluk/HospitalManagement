namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine
{
    public class GetAllMedicineQueryRequest : IRequest<OptResult<List<GetAllMedicineQueryResponse>>>
    {
        public string? Manufacturer { get; set; }
        public string? OrderBy { get; set; } = "Id ASC";

    }
}