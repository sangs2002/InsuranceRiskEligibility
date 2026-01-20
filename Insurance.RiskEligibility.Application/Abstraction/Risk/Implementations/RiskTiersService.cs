namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations
{
    public class RiskTiersService : IRiskTier
    {
        private readonly IEnumerable<IRiskTierRuler> _rules;

        public RiskTiersService(IEnumerable<IRiskTierRuler> rules)
        {
            _rules = rules;
        }

        public RiskTier Tier(int riskScore)
        {
            var rule = _rules.FirstOrDefault(r => r.Tier(riskScore));

            if (rule == null)
            {
                throw new InvalidOperationException($"No risk tier rule found for score {riskScore}");
            }

            return rule.Tier();
        }
    }
}
