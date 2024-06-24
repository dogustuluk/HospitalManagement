using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class MedicineDetailWriteRepository : WriteRepository<MedicineDetail>, IMedicineDetailWriteRepository
    {
        public MedicineDetailWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
