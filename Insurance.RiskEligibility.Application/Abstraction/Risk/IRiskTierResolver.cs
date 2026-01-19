namespace Insurance.RiskEligibility.Application.Abstraction.Risk
{
    public interface IRiskTierResolver
    {
        public RiskTier Resolve(int riskScore);
    }
}
