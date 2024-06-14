using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.Common
{
    public class AnyParam : BaseEntity
    {
        public int TargetModelId { get; set; }
        public int TargetModelType { get; set; }
        public int? ParamType { get; set; }
        public string? ItemModelName { get; set; }
        public string? AnyParamName1 { get; set; }
        public string? AnyParamName2 { get; set; }
        public bool isActive { get; set; }
        public int SortOrderNo { get; set; }

        public string? Value1 { get; set; }
        public string? Value2 { get; set; }
        public string? Value3 { get; set; }
        public string? Value4 { get; set; }
        public string? Value5 { get; set; }

        public bool? BoolValue1 { get; set; }
        public bool? BoolValue2 { get; set; }
        public bool? BoolValue3 { get; set; }
        public bool? BoolValue4 { get; set; }
        public bool? BoolValue5 { get; set; }

        public DateTime? DateTimeValue1 { get; set; }
        public DateTime? DateTimeValue2 { get; set; }
        public DateTime? DateTimeValue3 { get; set; }
        public DateTime? DateTimeValue4 { get; set; }
        public DateTime? DateTimeValue5 { get; set; }

    }
}
