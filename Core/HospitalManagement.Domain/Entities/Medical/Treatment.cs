using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Medical
{
    public class Treatment : BaseEntity
    {
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Duration { get; set; }
        public double? Cost { get; set; }
    }
}
