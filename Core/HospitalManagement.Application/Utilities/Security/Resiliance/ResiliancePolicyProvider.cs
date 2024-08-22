using Polly;
using ResilienceStrategy = HospitalManagement.Domain.Enums.ResilienceStrategy;

namespace HospitalManagement.Application.Utilities.Security.Resiliance
{
    public class ResiliencePolicyProvider : IResiliencePolicyProvider
    {
        public IAsyncPolicy GetPolicy(ResilienceStrategy strategy, ResiliencePolicyOptions options = null)
        {
            options ??= new ResiliencePolicyOptions();

            return strategy switch
            {
                //ResilienceStrategy.Retry => Policy.Handle<Exception>()
                //                                   .WaitAndRetryAsync(options.RetryCount, _ => options.RetryDelay),
                ResilienceStrategy.Retry => Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(
                        options.RetryCount,
                        _ => options.RetryDelay,
                        (exception, timeSpan, retryCount, context) =>
                        {
                            Console.WriteLine($"Deneme {retryCount} - Hata: {exception.Message}");
                        }),

                ResilienceStrategy.CircuitBreaker => Policy.Handle<Exception>()
                                                           .CircuitBreakerAsync(options.CircuitBreakerFailures, options.CircuitBreakerDuration),

                ResilienceStrategy.Timeout => Policy.TimeoutAsync(options.TimeoutDuration),

                ResilienceStrategy.Bulkhead => Policy.BulkheadAsync(options.BulkheadMaxParallelization, options.BulkheadMaxQueuingActions),

                ResilienceStrategy.Fallback => Policy.Handle<Exception>()
                .FallbackAsync(_ => options.FallbackActionWithException(default)),

                ResilienceStrategy.Custom => CreateCustomPolicy(options),

                _ => Policy.NoOpAsync(),
            };
        }

        private IAsyncPolicy CreateCustomPolicy(ResiliencePolicyOptions options)
        {
            return Policy.Handle<Exception>()
                         .RetryAsync(2)
                         .WrapAsync(Policy.TimeoutAsync(options.TimeoutDuration));
        }
    }
}