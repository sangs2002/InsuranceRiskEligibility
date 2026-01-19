namespace Insurance.RiskEligibility.Application.Command
{
    public interface IRiskEvaluationCommandService
    {
       Task<RiskEvaluationResult> EvaluateAsync(EligibilityRequest request);
    }
}
