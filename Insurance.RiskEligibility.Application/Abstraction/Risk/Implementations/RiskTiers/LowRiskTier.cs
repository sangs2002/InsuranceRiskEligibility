namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.RiskTiers
{
    public class LowRiskTier : IRiskTierRuler
    {
        public bool Tier(int riskScore)
        {
            return riskScore >= 0 && riskScore <= RiskConstants.RiskTier.LowRiskMaxScore;
        }

        public RiskTier Tier()
        {
            return RiskTier.Low;

        }
    }
}
