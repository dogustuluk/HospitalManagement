using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class MedicineDetailReadRepository : ReadRepository<MedicineDetail>, IMedicineDetailReadRepository
    {
        public MedicineDetailReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
