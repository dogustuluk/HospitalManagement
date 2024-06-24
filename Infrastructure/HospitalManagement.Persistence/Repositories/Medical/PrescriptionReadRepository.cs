using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class PrescriptionReadRepository : ReadRepository<Prescription>, IPrescriptionReadRepository
    {
        public PrescriptionReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
