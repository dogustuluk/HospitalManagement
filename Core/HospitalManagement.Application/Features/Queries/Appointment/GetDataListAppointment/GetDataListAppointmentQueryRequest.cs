namespace HospitalManagement.Application.Features.Queries.Appointment.GetDataListAppointment
{
    public class GetDataListAppointmentQueryRequest : IRequest<OptResult<List<GetDataListAppointmentQueryResponse>>>
    {
        public string? SelectedText { get; set; }
    }
}