using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class TreatmentReadRepository : ReadRepository<Treatment>, ITreatmentReadRepository
    {
        public TreatmentReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
