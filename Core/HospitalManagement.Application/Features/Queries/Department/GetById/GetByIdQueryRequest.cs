namespace HospitalManagement.Application.Features.Queries.Department.GetById
{
    public class GetByIdQueryRequest : IRequest<OptResult<GetByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
}