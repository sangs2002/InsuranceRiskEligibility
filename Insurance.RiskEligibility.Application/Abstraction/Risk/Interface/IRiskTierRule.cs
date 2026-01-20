namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Interface
{
    public interface IRiskTierRuler
    {
        bool Tier(int riskScore);
        RiskTier Tier();
    }
}
