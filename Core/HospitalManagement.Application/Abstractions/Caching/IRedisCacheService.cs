namespace HospitalManagement.Application.Abstractions.Caching
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task DeleteAsync(string key);
        Task<bool> ExistsAsync(string key);
    }
}
