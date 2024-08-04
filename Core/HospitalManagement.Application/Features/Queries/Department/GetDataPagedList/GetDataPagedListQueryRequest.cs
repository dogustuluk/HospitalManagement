namespace HospitalManagement.Application.Features.Queries.Department.GetDataPagedList
{
    public class GetDataPagedListQueryRequest : IRequest<OptResult<PaginatedList<Domain.Entities.Management.Department>>>
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ParentID { get; set; } = -99;
        public int ManagerMemberID { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public string? IDsColumn { get; set; }
        public string? IDsList { get; set; }
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}