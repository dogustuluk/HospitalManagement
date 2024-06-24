using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class MedicineWriteRepository : WriteRepository<Medicine>, IMedicineWriteRepository
    {
        public MedicineWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
