using Microsoft.Extensions.Hosting;

namespace HospitalManagement.Application.Services
{
    public class CityCacheHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CityCacheHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var cityService = scope.ServiceProvider.GetRequiredService<ICityService>();
                await cityService.GetDataListAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
