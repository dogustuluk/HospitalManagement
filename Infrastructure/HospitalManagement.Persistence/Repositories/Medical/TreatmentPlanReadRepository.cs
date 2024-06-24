using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class TreatmentPlanReadRepository : ReadRepository<TreatmentPlan>, ITreatmentPlanReadRepository
    {
        public TreatmentPlanReadRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
