namespace HospitalManagement.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
