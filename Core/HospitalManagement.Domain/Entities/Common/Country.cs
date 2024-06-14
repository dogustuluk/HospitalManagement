using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Common
{
    public class Country : BaseEntity
    {
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public bool isActive { get; set; }
        public int SortOrderNo { get; set; }
    }
}
              