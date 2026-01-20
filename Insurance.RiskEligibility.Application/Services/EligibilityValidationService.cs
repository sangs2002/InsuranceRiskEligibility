namespace Insurance.RiskEligibility.Application.Services
{
    public class EligibilityValidationService:IEligibilityValidationService
    {
        private readonly IEnumerable<ISpecification<EligibilityRequest>> _specifications;

        public EligibilityValidationService(
                   IEnumerable<ISpecification<EligibilityRequest>> specifications)
        {
            _specifications = specifications;
        }

        public ValidationResult Validate(EligibilityRequest request)
        {
     
            var error = _specifications
                .Where(spec => !spec.IsValid(request))
                .Select(spec => spec.ErrorMessage)
                .ToList();

            return error.Any() ? ValidationResult.Failure(error) 
                : ValidationResult.Success();
        }
    }
}
