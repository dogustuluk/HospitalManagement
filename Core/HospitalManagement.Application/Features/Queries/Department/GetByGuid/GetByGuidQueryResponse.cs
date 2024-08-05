namespace HospitalManagement.Application.Features.Queries.Department.GetByGuid
{
    public class GetByGuidQueryResponse
    {
        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ParentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public int SortOrderNo { get; set; }
        public int ManagerMemberId { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public bool isActive { get; set; }
    }
}