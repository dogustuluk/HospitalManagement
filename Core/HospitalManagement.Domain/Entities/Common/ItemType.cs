namespace HospitalManagement.Domain.Entities.Common
{
    public class ItemType : BaseEntity
    {
        public int ParentID { get; set; }
        public string? ItemTypeName { get; set; }
        public bool isUseAuthority { get; set; }
        public bool isForList { get; set; }
        public string? Params { get; set; }
        public string? AuthorityColumns { get; set; }
    }
}
