namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.RiskTiers
{
    public class HighRiskTier : IRiskTierRuler
    {
        public bool Tier(int riskScore)
        {
            return riskScore > RiskConstants.RiskTier.MediumRiskMaxScore;
        }

        public RiskTier Tier()
        {
            return RiskTier.High;

        }
    }
}
