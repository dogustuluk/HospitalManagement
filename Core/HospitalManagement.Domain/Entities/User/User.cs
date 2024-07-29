using HospitalManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public int UserType { get; set; }
        public string NameSurname { get; set; }
        public string? Gender { get; set; }
        public string? IdentityNo { get; set; }
        public string? GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public string? Email { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int StatusId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserDetailsJSON { get; set; }
        public DateTime? Experience { get; set; }
    }
}
