namespace HospitalManagement.Application.Utilities.Security.Resiliance
{
    public class ResiliencePolicyOptions
    {
        public int RetryCount { get; set; } = 3; // Varsayılan 3 kez tekrar deneme
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(2); // Varsayılan 2 saniye gecikme

        public int CircuitBreakerFailures { get; set; } = 2; // Varsayılan 2 başarısızlık
        public TimeSpan CircuitBreakerDuration { get; set; } = TimeSpan.FromMinutes(1); // Varsayılan 1 dakika devre kesme süresi

        public TimeSpan TimeoutDuration { get; set; } = TimeSpan.FromSeconds(10); // Varsayılan 10 saniye zaman aşımı süresi

        public int BulkheadMaxParallelization { get; set; } = 5; // Varsayılan 5 paralel işlem
        public int BulkheadMaxQueuingActions { get; set; } = 10; // Varsayılan 10 sıra bekleyen işlem

        public Func<Task> FallbackAction { get; set; } = () => Task.CompletedTask; // Varsayılan fallback işlemi
        public Func<Exception, Task> FallbackActionWithException { get; set; } = ex => Task.CompletedTask; // Varsayılan fallback işlemi

    }
}
