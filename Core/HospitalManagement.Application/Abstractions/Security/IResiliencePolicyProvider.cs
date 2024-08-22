using HospitalManagement.Application.Utilities.Security.Resiliance;
using Polly;

namespace HospitalManagement.Application.Abstractions.Security
{
    public interface IResiliencePolicyProvider
    {
        IAsyncPolicy GetPolicy(Domain.Enums.ResilienceStrategy strategy, ResiliencePolicyOptions options = null);
    }
}
