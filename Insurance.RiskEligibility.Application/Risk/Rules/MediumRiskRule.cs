namespace Insurance.RiskEligibility.Application.Risk.Rules
{
    public class MediumRiskRule : IRiskTierRuler
    {
        public bool CanResolve(int riskScore)
        {
            return riskScore > RiskConstants.RiskTierThresholds.LowRiskMaxScore && riskScore <= RiskConstants.RiskTierThresholds.MediumRiskMaxScore;
        }

        public RiskTier Resolve()
        {
            return RiskTier.Medium;

        }
    }
}
