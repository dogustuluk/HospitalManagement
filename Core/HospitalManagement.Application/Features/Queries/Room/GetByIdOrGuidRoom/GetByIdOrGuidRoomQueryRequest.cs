namespace HospitalManagement.Application.Features.Queries.Room.GetByIdOrGuidRoom
{
    public class GetByIdOrGuidRoomQueryRequest : IRequest<OptResult<GetByIdOrGuidRoomQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? guid { get; set; }
    }
}