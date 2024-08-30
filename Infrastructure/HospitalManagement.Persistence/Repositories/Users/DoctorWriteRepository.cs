using HospitalManagement.Application.Repositories.Users;
using HospitalManagement.Domain.Entities.Users;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Users
{
    public class DoctorWriteRepository : WriteRepository<Doctor>, IDoctorWriteRepository
    {
        public DoctorWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
