namespace HospitalManagement.Application.Features.Queries.Medicine.GetValueMedicine
{
    public class GetValueMedicineQueryRequest : IRequest<OptResult<GetValueMedicineQueryResponse>>
    {
        public string ColumnName { get; set; }
        public int DataId { get; set; }
    }
}