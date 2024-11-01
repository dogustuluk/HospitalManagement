﻿namespace HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<OptResult<CreateUserCommandResponse>>
    {
        public int UserType { get; set; }
        public string Guid { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Gender { get; set; }
        public string IdentityNo { get; set; }
        public string GSM { get; set; }
        public string GSMPersonal { get; set; }
        public string UserDetailsJson { get; set; }
        public string Address { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Experience { get; set; }

        public Create_Patient_Dto? PatientUser { get; set; }
        public DoctorDto? DoctorUser { get; set; }
    }
    public class DoctorDto
    {
        public int DoctorId { get; set; }
    }

}