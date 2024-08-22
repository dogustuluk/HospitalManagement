namespace HospitalManagement.Application.Features.Queries.Medicine.GetMedicineDetail
{
    public class GetMedicineDetailQueryRequest : IRequest<OptResult<GetMedicineDetailQueryResponse>>
    {
        public int Id { get; set; }
    }
}