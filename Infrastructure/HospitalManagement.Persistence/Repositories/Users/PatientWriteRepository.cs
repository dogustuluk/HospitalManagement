using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class PatientWriteRepository : WriteRepository<Patient>, IPatientWriteRepository
    {
        public PatientWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
