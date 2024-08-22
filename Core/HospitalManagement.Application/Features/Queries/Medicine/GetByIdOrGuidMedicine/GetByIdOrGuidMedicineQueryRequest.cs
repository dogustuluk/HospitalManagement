namespace HospitalManagement.Application.Features.Queries.Medicine.GetByIdOrGuidMedicine
{
    public class GetByIdOrGuidMedicineQueryRequest : IRequest<OptResult<GetByIdOrGuidMedicineQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? guid { get; set; }
    }
}