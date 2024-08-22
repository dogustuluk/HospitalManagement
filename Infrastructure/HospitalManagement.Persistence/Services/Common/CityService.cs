using HospitalManagement.Application.Abstractions.Caching;
using HospitalManagement.Application.Abstractions.Services.Common;
using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Repositories.Common;
using HospitalManagement.Application.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HospitalManagement.Persistence.Services.Common
{
    [Service(ServiceLifetime.Scoped)]
    public class CityService : ICityService
    {
        private readonly ICityReadRepository _readRepository;
        private readonly ICityWriteRepository _writeRepository;
        private readonly IRedisCacheService _redisCacheService;

        private const string CacheName = "CityDataList";

        public CityService(ICityReadRepository readRepository, ICityWriteRepository writeRepository, IRedisCacheService redisCacheService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<List<DataList1>> GetDataListAsync()
        {
            var cachedCities = await _redisCacheService.GetDataListAsync<DataList1>(CacheName);
            if (cachedCities != null)
            {
                return cachedCities;
            }

            var cities = await _readRepository.GetDataAsync(a => a.Id > 0, "", 10000, "CityName ASC");
            List<DataList1> returnDataList = cities
                .Select(data => new DataList1 { Guid = "", Id = data.Id.ToString(), Name = data.CityName })
                .ToList();

            await _redisCacheService.SetAsync(CacheName, returnDataList, TimeSpan.FromDays(365)); // Uzun süreli cache'leme

            return returnDataList;
        }
    }
}
