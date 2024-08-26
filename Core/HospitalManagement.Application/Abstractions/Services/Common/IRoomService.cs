using HospitalManagement.Application.Common.DTOs.Common;

namespace HospitalManagement.Application.Abstractions.Services.Common
{
    public interface IRoomService
    {
        Task<OptResult<Room>> CreateRoomAsync(Create_Room_Dto model);
        Task<OptResult<Room>> UpdateRoomAsync(Update_Room_Dto model);
        Task<OptResult<Room>> AppendPatientToRoomAsync(AppendPatientTo_Room_Dto model);
        Task<OptResult<Room>> RemovePatientFromRoomAsync(RemovePatientFrom_Room_Dto model);

        Task<List<Room>> GetAllRoomAsync(Expression<Func<Room, bool>>? predicate, string? include);
        Task<List<DataList1>> GetDataListAsync();
        Task<OptResult<Room>> GetByIdOrGuidAsync(object criteria);
        Task<OptResult<PaginatedList<Room>>> GetAllPagedListAsync(GetAllPaged_Room_Index_Dto model);
        Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType);
        Task<int> EmptyRoomOrBedCountAsync();
        Task<OptResult<bool>> GetRoomAvailabilityAsync(int roomId);
        Task<OptResult<int>> CheckRoomCapacityAsync(int roomId);
        Task<List<Room>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate);

    }
}
