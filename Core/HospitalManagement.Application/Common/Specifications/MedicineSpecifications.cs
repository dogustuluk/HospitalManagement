using HospitalManagement.Application.Common.DTOs.Medical;
using HospitalManagement.Application.Features.Queries.Medicine.GetAllMedicine;

namespace HospitalManagement.Application.Common.Specifications
{
    public class MedicineSpecifications
    {
        public Expression<Func<Medicine, bool>> GetAllPredicate(GetAllMedicineQueryRequest medicineRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Medicine>(true);


            return predicate1;
        }
        public Expression<Func<Medicine, bool>> GetAllPagedPredicate(GetAllPaged_Medicine_Index_Dto medicineRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Medicine>(true);

            if (!string.IsNullOrEmpty(medicineRequestParameters.SearchText))
                predicate1 = predicate1.And(a => a.Name.Contains(medicineRequestParameters.SearchText) || a.Manufacturer.Contains(medicineRequestParameters.SearchText));

            if (medicineRequestParameters.IsPrescriptionRequired > -1)
                predicate1 = predicate1.And(a => a.IsPrescriptionRequired == (medicineRequestParameters.IsPrescriptionRequired == -1 ? false : true));

            return predicate1;
        }
    }
}
