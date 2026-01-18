namespace Insurance.RiskEligibility.Application.Risk.Rules
{
    public class HighRiskRule : IRiskTierRuler
    {
        public bool CanResolve(int riskScore)
        {
            return riskScore > RiskConstants.RiskTierThresholds.MediumRiskMaxScore;
        }

        public RiskTier Resolve()
        {
            return RiskTier.High;

        }
    }
}
