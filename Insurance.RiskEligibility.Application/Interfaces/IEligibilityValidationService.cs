namespace Insurance.RiskEligibility.Application.Interfaces
{
    public interface IEligibilityValidationService
    {
        ValidationResult Validate(EligibilityRequest request);
    }
}
