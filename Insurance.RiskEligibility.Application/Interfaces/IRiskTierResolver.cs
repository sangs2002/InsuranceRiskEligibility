namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IRiskTierResolver
    {
        public RiskTier Resolve(int riskScore);
    }
}
