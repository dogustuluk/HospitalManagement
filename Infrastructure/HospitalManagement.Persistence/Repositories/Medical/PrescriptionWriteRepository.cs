using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class PrescriptionWriteRepository : WriteRepository<Prescription>, IPrescriptionWriteRepository
    {
        public PrescriptionWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
