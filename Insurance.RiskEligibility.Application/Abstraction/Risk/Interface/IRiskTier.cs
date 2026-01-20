namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Interface
{
    public interface IRiskTier
    {
        public RiskTier Tier(int riskScore);
    }
}
