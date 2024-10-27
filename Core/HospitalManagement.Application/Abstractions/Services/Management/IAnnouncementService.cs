namespace HospitalManagement.Application.Abstractions.Services.Management
{
    public interface IAnnouncementService
    {
        Task<OptResult<Announcement>> CreateAnnouncementAsync(Create_Announcemnet_Dto model);
        Task<OptResult<Announcement>> UpdateAnnouncementAsync(Update_Announcemnet_Dto model);
        Task<OptResult<Announcement>> DeleteAnnouncementAsync(object value, int deleteType);
        Task<OptResult<Announcement>> GetByIdOrGuid(object criteria);
        Task<List<Announcement>> GetAllAnnouncementAsync(Expression<Func<Announcement, bool>>? predicate, string? include);
        Task<OptResult<PaginatedList<Announcement>>> GetAllPagedAnnouncementAsync(GetAllPaged_Announcement_Dto model);
        Task<string> GetValue(string? table, string column, string sqlQuery, int? dbType);
    }
}
