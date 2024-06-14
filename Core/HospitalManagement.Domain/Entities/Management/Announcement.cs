﻿using HospitalManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Management
{
    public class Announcement : BaseEntity
    {
        public string UserTypeIds { get; set; }
        public string AnnouncementTitle { get; set; }
        public string? AnnouncementContent { get; set; }
        public string? FilePath { get; set; }
        public DateTime VisibleDate { get; set; }
        public int VisibleDays { get; set; }
        public bool isSpot { get; set; }
        public bool isMustAccept { get; set; }
        public string? ReadLogs { get; set; }
        public bool isActive { get; set; }
    }
}
