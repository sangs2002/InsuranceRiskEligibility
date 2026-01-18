namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IRiskCalculationStrategy
    {
        int CalculateRiskScore(EligibilityRequest request);
    }
}
