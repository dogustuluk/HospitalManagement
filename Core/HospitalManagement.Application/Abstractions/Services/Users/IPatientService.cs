using HospitalManagement.Domain.Entities.Users;

namespace HospitalManagement.Application.Abstractions.Services.Users
{
    public interface IPatientService
    {
        Task<OptResult<Patient>> CreateAsync(Create_Patient_Dto model);

    }
}
