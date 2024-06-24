namespace HospitalManagement.Application.DTOs.User
{
    public class CreateUser_Dto
    {
        public string Guid { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
