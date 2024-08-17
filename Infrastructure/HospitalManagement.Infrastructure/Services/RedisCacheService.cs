using StackExchange.Redis;
using Newtonsoft.Json;
using HospitalManagement.Application.Abstractions.Caching;
using HospitalManagement.Application.Common.GenericObjects;

namespace HospitalManagement.Infrastructure.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _database;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }

        public async Task DeleteAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return await _database.KeyExistsAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty)
                return default;
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            await _database.StringSetAsync(key, serializedValue, expiration);
        }

        public async Task<PaginatedList<T>> GetPaginatedListAsync<T>(string cachePrefixName, int pageIndex, Func<int, Task<PaginatedList<T>>> data) where T : class
        {
            if (pageIndex > 3)
            {
                string currentPage = $"{cachePrefixName}_{pageIndex}";
                string oldPage1 = $"{cachePrefixName}_{pageIndex - 2}";
                string oldPage2 = $"{cachePrefixName}_{pageIndex - 1}";

                await DeleteAsync(currentPage);
                await DeleteAsync(oldPage1);
                await DeleteAsync(oldPage2);
            }

            string currentPagePrefix = $"{cachePrefixName}_{pageIndex}";
            string nextPagePrefix1 = $"{cachePrefixName}_{pageIndex + 1}";
            string nextPagePrefix2 = $"{cachePrefixName}_{pageIndex + 2}";


            var cachedData = await GetAsync<PaginatedList<T>>(currentPagePrefix);
            if (cachedData != null) return cachedData;

            var currentPageCachedata = await data(pageIndex);
            if (currentPageCachedata.Data.Count > 0)
            {
                await SetAsync(currentPagePrefix, currentPageCachedata);

                var nextPage1Data = await data(pageIndex + 1);
                if (nextPage1Data.Data.Count > 0) await SetAsync(nextPagePrefix1, nextPage1Data);

                var nextPage2Data = await data(pageIndex + 2);
                if (nextPage2Data.Data.Count > 0) await SetAsync(nextPagePrefix2, nextPage2Data);

            }
            return currentPageCachedata;
        }
    }
}
