namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations
{
    public class RiskStrategyFactory : IRiskStrategyFactory
    {
        private readonly Dictionary<PolicyType, IRiskCalculationStrategy> _strategies;

        public RiskStrategyFactory(IEnumerable<IRiskCalculationStrategy> strategies)
        {   
            _strategies = strategies.ToDictionary(s => s.PolicyType);
        }

        public IRiskCalculationStrategy GetStrategy(PolicyType policyType)
        {
            if (_strategies.TryGetValue(policyType, out var strategy))
            {
                return strategy;
            }

            throw new NotSupportedException(
                $"Risk strategy doesn't contains the policy type '{policyType}'.");
        }
    }
}
