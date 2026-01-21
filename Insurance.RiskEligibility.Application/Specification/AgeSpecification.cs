namespace Insurance.RiskEligibility.Application.Specification
{
    public class AgeSpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage => $"Customer age must be between {EligibilityConstants.MinAge} and {EligibilityConstants.MaxAge} years.";

        public bool IsValid(EligibilityRequest entity)
        {
            var age = entity.Age;
            return age >= EligibilityConstants.MinAge && age <= EligibilityConstants.MaxAge;

        }
    }
}
