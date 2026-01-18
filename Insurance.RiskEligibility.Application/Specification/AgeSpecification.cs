using Insurance.RiskEligibility.Application.Interfaces;

namespace Insurance.RiskEligibility.Application.Specification
{
    public class AgeSpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage => $"Customer age must be between {EligibilityConstants.MinAge} and {EligibilityConstants.MaxAge} years.";

        public bool IsSatisfiedBy(EligibilityRequest entity)
        {
            var age = AgeCalculator.CalculateAge(entity.DateOfBirth);
            return age >= EligibilityConstants.MinAge && age <= EligibilityConstants.MaxAge;

        }
    }
}
