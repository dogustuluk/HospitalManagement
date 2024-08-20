namespace HospitalManagement.Application.Features.Queries.Hospital.GetByIdorGuidHospital
{
    public class GetByIdOrGuidHospitalQueryRequest : IRequest<OptResult<GetByIdOrGuidHospitalQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? guid { get; set; }
    }
}