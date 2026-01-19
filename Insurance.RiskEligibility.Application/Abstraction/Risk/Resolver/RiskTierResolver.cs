namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Resolver
{
    public class RiskTierResolver : IRiskTierResolver
    {
        private readonly IEnumerable<IRiskTierRuler> _rules;

        public RiskTierResolver(IEnumerable<IRiskTierRuler> rules)
        {
            _rules = rules;
        }

        public RiskTier Resolve(int riskScore)
        {
            var rule = _rules.FirstOrDefault(r => r.CanResolve(riskScore));

            if (rule == null)
            {
                throw new InvalidOperationException($"No risk tier rule found for score {riskScore}");
            }

            return rule.Resolve();
        }
    }
}
