namespace HospitalManagement.Application.Common.Specifications
{
    public class DepartmentSpecifications
    {
        public Expression<Func<Department, bool>> GetAllPredicate(GetAllDepartmentQueryRequest departmentRequestParameters)
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
        public Expression<Func<Department, bool>> GetDataPagedListPredicate(GetAllPaged_Index_Dto getDataPagedListRequest)
        {
            var predicate1 = PredicateBuilder.New<Department>(true);

            if (!string.IsNullOrEmpty(getDataPagedListRequest.SearchText))
                predicate1 = predicate1.And(a => a.DepartmentName.Contains(getDataPagedListRequest.SearchText) || a.DepartmentCode.Contains(getDataPagedListRequest.SearchText));

            if (getDataPagedListRequest.ParentID > 0)
                predicate1 = predicate1.And(a => a.ParentId == getDataPagedListRequest.ParentID);

            if (getDataPagedListRequest.ManagerMemberID > 0)
                predicate1 = predicate1.And(a => a.ManagerMemberId == getDataPagedListRequest.ManagerMemberID);

            if (getDataPagedListRequest.ActiveStatus != 0)
                predicate1 = predicate1.And(a => a.isActive == (getDataPagedListRequest.ActiveStatus == -1 ? false : true));

            if (!string.IsNullOrEmpty(getDataPagedListRequest.IDsList))
            {
                List<int> ids = getDataPagedListRequest.IDsList.Split(',').Select(int.Parse).ToList();
                if (string.IsNullOrEmpty(getDataPagedListRequest.IDsColumn) || getDataPagedListRequest.IDsColumn == "Id")
                    predicate1 = predicate1.And(a => ids.Contains(a.Id));
            }

            return predicate1;
        }
    }
}
