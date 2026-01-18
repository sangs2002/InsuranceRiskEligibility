namespace Insurance.RiskEligibility.Application.Risk.Factories
{
    public class RiskStrategyFactory : IRiskStrategyFactory
    {
        private readonly Dictionary<PolicyType, IRiskCalculationStrategy> _strategies;

        public RiskStrategyFactory(Dictionary<PolicyType, IRiskCalculationStrategy> strategies)
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
