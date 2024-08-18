namespace HospitalManagement.Application.Features.Queries.Appointment.GetByIdAppointment
{
    public class GetByIdOrGuidAppointmentQueryRequest : IRequest<OptResult<GetByIdOrGuidAppointmentQueryResponse>>
    {
        public int? Id { get; set; }
        public Guid? guid { get; set; }
    }
}