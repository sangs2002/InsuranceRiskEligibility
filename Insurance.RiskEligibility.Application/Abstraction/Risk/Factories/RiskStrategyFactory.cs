namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Factories
{
    public class RiskStrategyFactory : IRiskStrategyFactory
    {
        private readonly IReadOnlyDictionary<PolicyType, IRiskCalculationStrategy> _strategies;

        public RiskStrategyFactory(IReadOnlyDictionary<PolicyType, IRiskCalculationStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IRiskCalculationStrategy GetStrategy(PolicyType policyType)
        {
            if (_strategies.TryGetValue(policyType, out var strategy))
            {
                return strategy;
            }

            throw new NotSupportedException(
                $"Risk calculation strategy is not configured for policy type '{policyType}'.");
        }
    }
}
