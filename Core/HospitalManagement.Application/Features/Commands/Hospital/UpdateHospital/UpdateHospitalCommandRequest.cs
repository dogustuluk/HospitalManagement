namespace HospitalManagement.Application.Features.Commands.Hospital.UpdateHospital
{
    public class UpdateHospitalCommandRequest : IRequest<OptResult<UpdateHospitalCommandResponse>>
    {
        public Guid Guid { get; set; }
        public string HospitalName { get; set; }
        public string HospitalDetailJson { get; set; }

    }
}