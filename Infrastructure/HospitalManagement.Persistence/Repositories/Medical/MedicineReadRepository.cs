using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class MedicineReadRepository : ReadRepository<Medicine>, IMedicineReadRepository
    {
        public MedicineReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
