namespace HospitalManagement.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ResilienceAttribute : Attribute
    {
        public ResilienceStrategy Strategy { get; }
        
        public int RetryCount { get; set; } = 3; 
        public int RetryDelaySeconds { get; set; } = 2; 
        public int CircuitBreakerFailureThreshold { get; set; } = 2;
        public int CircuitBreakerDurationSeconds { get; set; } = 60;
        public int TimeoutSeconds { get; set; } = 10; 
        public int BulkheadMaxParallelization { get; set; } = 5; 
        public int BulkheadMaxQueuingActions { get; set; } = 10; 

        public ResilienceAttribute(ResilienceStrategy strategy)
        {
            Strategy = strategy;
        }
    }
}
