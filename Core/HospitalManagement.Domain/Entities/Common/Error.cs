using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Common
{
    public class Error : BaseEntity
    {
        public string? ErrorUrl { get; set; }
        public string? ErrorDesc { get; set; }
        public string? Operation { get; set; }
        public string? ErrorPlace { get; set; }
        public int AppUserId { get; set; }
    }
}
