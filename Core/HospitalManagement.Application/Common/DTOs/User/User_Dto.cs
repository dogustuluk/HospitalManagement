﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Common.DTOs.User
{
    public class CreateUser_Dto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string IdentityNo { get; set; }
        public string GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class UpdateUser_Dto
    {
        public Guid Guid { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Gender { get; set; }
        public string IdentityNo { get; set; }
        public string GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public string? UserDetailsJSON { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? Experience { get; set; }
    }
    public class GetAllPagedUser_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
}
