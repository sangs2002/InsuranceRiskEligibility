namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IRiskEvaluationService
    {
        RiskEvaluationResult Evaluate(EligibilityRequest request);
    }
}
