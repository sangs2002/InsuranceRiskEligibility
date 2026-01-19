namespace Insurance.RiskEligibility.Application.Abstraction.Risk
{
    public interface IRiskTierRuler
    {
        bool CanResolve(int riskScore);
        RiskTier Resolve();
    }
}
