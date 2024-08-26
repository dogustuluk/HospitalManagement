using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Room.GetAllRoom;

namespace HospitalManagement.Application.Common.Specifications
{
    public class RoomSpecifications
    {
        public Expression<Func<Room, bool>> GetAllPredicate(GetAllRoomQueryRequest requestParameters)
        {
            var predicate1 = PredicateBuilder.New<Room>(true);

            if (requestParameters.Floor > 0)
                predicate1 = predicate1.And(a => a.Floor == requestParameters.Floor);

            if (requestParameters.RoomType > 0)
                predicate1 = predicate1.And(a => a.RoomType == requestParameters.RoomType);

            if (requestParameters.DepartmentId > 0)
                predicate1 = predicate1.And(a => a.DepartmentId == requestParameters.DepartmentId);

            return predicate1;
        }
        public Expression<Func<Room, bool>> GetAllPagedPredicate(GetAllPaged_Room_Index_Dto requestParameters)
        {
            var predicate1 = PredicateBuilder.New<Room>(true);

            if (requestParameters.Floor > 0)
                predicate1 = predicate1.And(a => a.Floor == requestParameters.Floor);

            if (requestParameters.RoomType > 0)
                predicate1 = predicate1.And(a => a.RoomType == requestParameters.RoomType);

            if (requestParameters.DepartmentId > 0)
                predicate1 = predicate1.And(a => a.DepartmentId == requestParameters.DepartmentId);

            return predicate1;
        }
        
    }
}
