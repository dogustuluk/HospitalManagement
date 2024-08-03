namespace HospitalManagement.Application.Common.Specifications
{
    public class DepartmentSpecifications
    {
        public Expression<Func<Department, bool>> GetPredicate(GetAllDepartmentQueryRequest departmentRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Department>(true);

            if (!string.IsNullOrEmpty(departmentRequestParameters.SearchText))
                predicate1 = predicate1.And(a => a.DepartmentName.Contains(departmentRequestParameters.SearchText) || a.DepartmentCode.Contains(departmentRequestParameters.SearchText));

            if (departmentRequestParameters.ParentID > 0)
                predicate1 = predicate1.And(a => a.ParentId == departmentRequestParameters.ParentID);

            if (departmentRequestParameters.ManagerMemberId > 0)
                predicate1 = predicate1.And(a => a.ManagerMemberId == departmentRequestParameters.ManagerMemberId);

            if (!string.IsNullOrEmpty(departmentRequestParameters.DepartmentCode))
                predicate1 = predicate1.And(a => a.DepartmentCode.Contains(departmentRequestParameters.DepartmentCode));

            if (!string.IsNullOrEmpty(departmentRequestParameters.DepartmentName))
                predicate1 = predicate1.And(a => a.DepartmentName.Contains(departmentRequestParameters.DepartmentName));

            return predicate1;
        }
    }
}
