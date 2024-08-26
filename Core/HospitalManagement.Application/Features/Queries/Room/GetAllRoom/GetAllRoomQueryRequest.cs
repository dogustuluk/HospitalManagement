namespace HospitalManagement.Application.Features.Queries.Room.GetAllRoom
{
    public class GetAllRoomQueryRequest : IRequest<OptResult<List<GetAllRoomQueryResponse>>>
    {
        public int? DepartmentId { get; set; }
        public int? RoomType { get; set; }
        public int? Floor { get; set; }
        public string? OrderBy { get; set; } = "Id ASC";
    }
}