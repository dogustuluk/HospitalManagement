namespace HospitalManagement.Application.Features.Queries.Medicine.GetAllPagedMedicine
{
    public class GetAllPagedMedicineQueryRequest : IRequest<OptResult<PaginatedList<GetAllPagedMedicineQueryResponse>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int IsPrescriptionRequired { get; set; } = -1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}