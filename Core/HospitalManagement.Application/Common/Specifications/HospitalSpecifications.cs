using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;
using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Application.Common.Specifications
{
    public class HospitalSpecifications
    {
        public Expression<Func<Hospital, bool>> GetAllPredicate(GetAllHospitalQueryRequest hospitalRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Hospital>(true);


            return predicate1;
        }
        public Expression<Func<Hospital, bool>> GetAllPagedPredicate(GetAllPagedHospital_Index_Dto hospitalRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Hospital>(true);


            return predicate1;
        }
    }
}
