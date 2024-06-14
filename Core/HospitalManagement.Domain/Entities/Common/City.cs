namespace HospitalManagement.Domain.Entities.Common
{
    public class City : BaseEntity
    {
        public City()
        {
            Countys = new List<County>();
        }

        public int RefNo { get; set; }
        public int CountryID { get; set; }
        public string? CityName { get; set; }
        public double KOORX { get; set; }
        public double KOORY { get; set; }
        public bool isActive { get; set; }
        public int SortOrderNo { get; set; }

        public virtual ICollection<County> Countys { get; set; }
    }
}
