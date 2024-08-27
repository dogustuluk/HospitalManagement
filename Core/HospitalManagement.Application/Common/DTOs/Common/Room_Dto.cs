using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Common.DTOs.Common
{
    public class GetAllPaged_Room_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public int? Floor { get; set; }
        public int? RoomType { get; set; }
        public int? DepartmentId { get; set; }
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
    public class Create_Room_Dto
    {
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; } //1 ise => 2 kisilik, 2 ise => 3 kisilik, 3 ise => 4 kisilik
        public List<string> PatientIds { get; set; }
    }
    public class Update_Room_Dto
    {
        public Guid Guid { get; set; }
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; } //1 ise => 2 kisilik, 2 ise => 3 kisilik, 3 ise => 4 kisilik
        public List<string> PatientIds { get; set; }
    }
    public class AvailabilityBedIn_Room_Dto
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public List<int> RoomBedNumber { get; set; }
    }
    public class AppendPatientTo_Room_Dto
    {
        
    }
    public class RemovePatientFrom_Room_Dto
    {

    }
}
