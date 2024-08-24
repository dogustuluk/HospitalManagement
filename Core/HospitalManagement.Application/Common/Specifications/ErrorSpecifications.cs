using HospitalManagement.Application.Common.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Common.Specifications
{
    public class ErrorSpecifications
    {
        public Expression<Func<Error, bool>> GetAllPagedPredicate(GetAllPaged_Error_Dto errorRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Error>(true);

            if (!string.IsNullOrEmpty(errorRequestParameters.SearchText))
                predicate1 = predicate1.And(a => a.ErrorUrl.Contains(errorRequestParameters.SearchText));

            if (errorRequestParameters.ErrorType > 0)
                predicate1 = predicate1.And(a => a.ErrorType == errorRequestParameters.ErrorType);

            return predicate1;
        }
    }
}
