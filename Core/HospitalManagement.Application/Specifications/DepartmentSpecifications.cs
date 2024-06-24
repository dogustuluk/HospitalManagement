using HospitalManagement.Application.Features.Queries.Department.GetAllDepartment;
using HospitalManagement.Domain.Entities.Management;
using LinqKit;
using System.Linq.Expressions;

namespace HospitalManagement.Application.Specifications
{
    public class DepartmentSpecifications
    {
        public Expression<Func<Department,bool>> GetPredicate(GetAllDepartmentQueryRequest departmentRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Department>(true);
            
            if (!string.IsNullOrEmpty(departmentRequestParameters.DepartmentCode))
                predicate1 = predicate1.And(a => a.DepartmentCode.Contains(departmentRequestParameters.DepartmentCode));
            
            if (!string.IsNullOrEmpty(departmentRequestParameters.DepartmentName))
                predicate1 = predicate1.And(a => a.DepartmentName.Contains(departmentRequestParameters.DepartmentName));
 
            return predicate1;

        }
    }
}
