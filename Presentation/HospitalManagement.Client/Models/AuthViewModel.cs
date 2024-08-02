using HospitalManagement.Application.DTOs;

namespace HospitalManagement.Client.Models
{
    public class LoginViewModel
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool isSigned { get; set; } = false;
        public Token? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
