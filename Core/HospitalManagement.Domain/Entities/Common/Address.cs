using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Common
{
    public class Address : BaseEntity
    {
        public int CityId { get; set; }
        public int CountyId { get; set; }
        public int CountryId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string PhoneNumber { get; set; }
    }
}
