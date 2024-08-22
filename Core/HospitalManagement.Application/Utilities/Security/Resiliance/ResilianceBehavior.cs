using Polly;

namespace HospitalManagement.Application.Utilities.Security.Resiliance
{
    public class ResilianceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IResiliencePolicyProvider _resiliencePolicyProvider;

        public ResilianceBehavior(IResiliencePolicyProvider resiliencePolicyProvider)
        {
            _resiliencePolicyProvider = resiliencePolicyProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var attributes = request.GetType().GetCustomAttributes<ResilienceAttribute>(true);
            IAsyncPolicy policy = Policy.NoOpAsync();

            var options = new ResiliencePolicyOptions
            {
                RetryCount = 5,
                RetryDelay = TimeSpan.FromSeconds(1)
            };

            foreach (var attribute in attributes)
            {
                var currentPolicy = _resiliencePolicyProvider.GetPolicy(attribute.Strategy, options);
                policy = policy.WrapAsync(currentPolicy);
            }

            return await policy.ExecuteAsync(() => next());
        }
    }

}
