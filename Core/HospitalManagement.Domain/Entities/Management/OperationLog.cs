﻿using HospitalManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Management
{
    public class OperationLog : BaseEntity
    {
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public double DoubleValue1 { get; set; }
        public double DoubleValue2 { get; set; }
        public string? OperationDesc { get; set; }
        public string? StringValue1 { get; set; }
        public string? StringValue2 { get; set; }
        public string? UserIp { get; set; }
    }
}
