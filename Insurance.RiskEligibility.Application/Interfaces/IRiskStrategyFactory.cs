namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IRiskStrategyFactory
    {
        IRiskCalculationStrategy GetStrategy(PolicyType policyType);
    }
}
