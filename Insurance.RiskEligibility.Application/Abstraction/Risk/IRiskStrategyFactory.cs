namespace Insurance.RiskEligibility.Application.Abstraction.Risk
{
    public interface IRiskStrategyFactory
    {
        IRiskCalculationStrategy GetStrategy(PolicyType policyType);
    }
}
