namespace HospitalManagement.Application.Features.Queries.Appointment.GetValueAppointment
{
    public class GetValueAppointmentQueryRequest : IRequest<OptResult<GetValueAppointmentQueryResponse>>
    {
        public string ColumnName { get; set; }
        public int DataId { get; set; }
    }
}