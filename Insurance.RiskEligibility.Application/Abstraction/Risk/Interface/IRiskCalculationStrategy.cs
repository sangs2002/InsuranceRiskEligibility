namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Interface
{
    public interface IRiskCalculationStrategy
    {
        int CalculateRiskScore(EligibilityRequest request);
        PolicyType PolicyType { get; }

    }
}
