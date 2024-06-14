using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Management
{
    public class Reminder : BaseEntity
    {
        public string? UId { get; set; }
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public int ReminderTypeId { get; set; }
        public string ReminderType { get; set; }
        public string? ReminderName { get; set; }
        public string? ReminderDesc { get; set; }
        public DateTime ReminderDate { get; set; }
        public string? UserIds { get; set; }
        public int Status { get; set; }
        public int Param1 { get; set; }
        public string? Param2 { get; set; }
        public bool isDeleted { get; set; }
        public string? DeletedInfo { get; set; }
        public string? SendLogs { get; set; }

    }
}
