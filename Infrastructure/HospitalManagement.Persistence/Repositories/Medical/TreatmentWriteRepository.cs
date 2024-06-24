using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class TreatmentWriteRepository : WriteRepository<Treatment>, ITreatmentWriteRepository
    {
        public TreatmentWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
