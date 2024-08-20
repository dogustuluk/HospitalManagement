namespace HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital
{
    public class GetAllPagedHospitalQueryRequest : IRequest<OptResult<PaginatedList<GetAllPagedHospitalQueryResponse>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}