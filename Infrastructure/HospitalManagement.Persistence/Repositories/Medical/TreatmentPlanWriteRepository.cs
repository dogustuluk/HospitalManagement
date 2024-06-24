using HospitalManagement.Application.Repositories.Medical;
using HospitalManagement.Domain.Entities.Medical;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Persistence.Repositories.Medical
{
    public class TreatmentPlanWriteRepository : WriteRepository<TreatmentPlan>, ITreatmentPlanWriteRepository
    {
        public TreatmentPlanWriteRepository(HospitalManagementDbContext context) : base(context)
        {
        }
    }
}
