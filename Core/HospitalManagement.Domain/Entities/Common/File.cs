using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Common
{
    public class File : BaseEntity
    {
        public int M_ItemType { get; set; } 
        public int M_ItemID { get; set; } 
        public int T_ItemType { get; set; } 
        public int T_ItemID { get; set; } 
        public int ParamID { get; set; } 
        public int FileTypeID { get; set; } 
        public string? FileNo { get; set; }
        public string? FileURL { get; set; }
        public string? FileDesc { get; set; }
        public double FileSize { get; set; }
        public DateTime? FileDate { get; set; }
        public DateTime? FileDate2 { get; set; }
        public bool isCloud { get; set; }
        public bool isActive { get; set; }
        public bool isReminder { get; set; }
        public bool isHidden { get; set; }
        public bool isDeleted { get; set; }
        public string? DeletedInfo { get; set; }
        public double Param1 { get; set; }
        public string? Param2 { get; set; }
    }
}
