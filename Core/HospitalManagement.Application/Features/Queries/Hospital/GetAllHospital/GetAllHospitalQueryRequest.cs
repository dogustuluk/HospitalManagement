namespace HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital
{
    public class GetAllHospitalQueryRequest : IRequest<OptResult<List<GetAllHospitalQueryResponse>>>
    {
        public string? OrderBy { get; set; } = "Id ASC";
        public bool EmergencyService { get; set; }
    }
}