using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class DoctorReadRepository : ReadRepository<Doctor>, IDoctorReadRepository
    {
        public DoctorReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
