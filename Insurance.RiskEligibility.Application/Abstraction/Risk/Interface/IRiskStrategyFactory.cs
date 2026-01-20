namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Interface
{
    public interface IRiskStrategyFactory
    {
        IRiskCalculationStrategy GetStrategy(PolicyType policyType);
    }
}
