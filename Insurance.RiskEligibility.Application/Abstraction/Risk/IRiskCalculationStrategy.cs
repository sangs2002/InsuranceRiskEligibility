namespace Insurance.RiskEligibility.Application.Abstraction.Risk
{
    public interface IRiskCalculationStrategy
    {
        int CalculateRiskScore(EligibilityRequest request);
    }
}
