﻿namespace HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment
{
    public class GetAllAppointmentQueryResponse
    {
        public string NameSurname { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Status { get; set; }

        public int HospitalId { get; set; }
        public int ClinicId { get; set; }
        public string ExaminationPlace { get; set; }
        public string EMail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public string? Desc { get; set; }
        public DateTime VisitorAppointmentDate { get; set; }
    }
}