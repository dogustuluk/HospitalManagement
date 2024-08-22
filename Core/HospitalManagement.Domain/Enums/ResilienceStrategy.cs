namespace HospitalManagement.Domain.Enums
{
    public enum ResilienceStrategy
    {
        Default,
        Retry,
        CircuitBreaker,
        Timeout,
        Bulkhead,
        Fallback,
        Custom
    }
}
