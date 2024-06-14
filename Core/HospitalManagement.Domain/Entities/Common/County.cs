namespace HospitalManagement.Domain.Entities.Common
{
    public class County : BaseEntity
    {
        public int RefNo { get; set; }
        public string? CountyName { get; set; }
        public int CityId { get; set; }
        public double KOORX { get; set; }
        public double KOORY { get; set; }
        
        public virtual City? City { get; set; }
    }
}
