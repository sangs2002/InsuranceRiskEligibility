namespace Insurance.RiskEligibility.Application.Command
{
    public interface IRiskCommandService
    {
       Task<RiskEvaluationResult> EvaluateAsync(EligibilityRequest request);
    }
}
