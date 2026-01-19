namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Rules
{
    public class LowRiskRule : IRiskTierRuler
    {
        public bool CanResolve(int riskScore)
        {
            return riskScore >= 0 && riskScore <= RiskConstants.RiskTierThresholds.LowRiskMaxScore;
        }

        public RiskTier Resolve()
        {
            return RiskTier.Low;

        }
    }
}
