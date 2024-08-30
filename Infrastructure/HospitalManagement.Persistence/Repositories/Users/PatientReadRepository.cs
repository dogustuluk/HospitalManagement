using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
    {
        public PatientReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
