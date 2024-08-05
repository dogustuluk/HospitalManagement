namespace HospitalManagement.Application.Features.Queries.Department.GetDataPagedList
{
    public class GetDataPagedListQueryResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int ParentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public bool isActive { get; set; }
    }
}