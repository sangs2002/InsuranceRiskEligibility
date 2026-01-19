namespace Insurance.RiskEligibility.Application.Abstraction.Validation
{
    public interface IEligibilityValidationService
    {
        ValidationResult Validate(EligibilityRequest request);
    }
}
