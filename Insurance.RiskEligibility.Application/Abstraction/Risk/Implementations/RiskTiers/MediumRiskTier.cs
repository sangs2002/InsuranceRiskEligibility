namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.RiskTiers
{
    public class MediumRiskTier : IRiskTierRuler
    {
        public bool Tier(int riskScore)
        {
            return riskScore > RiskConstants.RiskTier.LowRiskMaxScore && riskScore <= RiskConstants.RiskTier.MediumRiskMaxScore;
        }

        public RiskTier Tier()
        {
            return RiskTier.Medium;

        }
    }
}
