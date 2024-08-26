namespace HospitalManagement.Application.Features.Queries.Room.GetAllPagedRoom
{
    public class GetAllPagedRoomQueryRequest : IRequest<OptResult<PaginatedList<GetAllPagedRoomQueryResponse>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int? Floor { get; set; }
        public int? RoomType { get; set; }
        public int? DepartmentId { get; set; }
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}