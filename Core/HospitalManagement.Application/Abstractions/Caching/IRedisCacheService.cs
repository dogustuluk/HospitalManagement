namespace HospitalManagement.Application.Abstractions.Caching
{
    public interface IRedisCacheService
    {
        bool IsConnected { get; }
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task DeleteAsync(string key);
        Task<bool> ExistsAsync(string key);
        Task<PaginatedList<T>> GetPaginatedListAsync<T>(string cachePrefixName, int pageIndex, Func<int, Task<PaginatedList<T>>> data) where T : class;
    }
}
