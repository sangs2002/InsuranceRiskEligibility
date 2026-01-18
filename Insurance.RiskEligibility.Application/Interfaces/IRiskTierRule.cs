namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IRiskTierRuler
    {
        bool CanResolve(int riskScore);
        RiskTier Resolve();
    }
}
