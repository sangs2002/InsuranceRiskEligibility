using Insurance.RiskEligibility.Application.Interfaces;

namespace Insurance.RiskEligibility.Application.Specification
{
    public class PolicyTypeSpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage => "Unsupported policy type.";

        public bool IsSatisfiedBy(EligibilityRequest entity)
        {
            return Enum.IsDefined(typeof(PolicyType), entity.PolicyType);
        }
    }
}
