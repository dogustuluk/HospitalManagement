namespace HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital
{
    [Resilience(ResilienceStrategy.Retry, RetryCount = 5, RetryDelaySeconds = 1)]
    public class GetAllHospitalQueryRequest : IRequest<OptResult<List<GetAllHospitalQueryResponse>>>
    {
        public string? OrderBy { get; set; } = "Id ASC";
        public bool EmergencyService { get; set; }
    }
}