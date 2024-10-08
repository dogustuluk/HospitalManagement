﻿namespace HospitalManagement.Domain.Entities.Common
{
    public class Room : BaseEntity
    {
        public Room()
        {
            Beds = new List<Bed>();
        }
        public int HospitalId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int DepartmentId { get; set; }
        public int RoomType { get; set; } //1 ise => 2 kisilik, 2 ise => 3 kisilik, 3 ise => 4 kisilik

        public List<Bed> Beds { get; set; }
    }
}
