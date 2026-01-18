using Insurance.RiskEligibility.Application.Interfaces;

namespace Insurance.RiskEligibility.Application.Specification
{
    public class AccidentHistorySpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage => $"Accident count must not exceed {EligibilityConstants.MaxAccidentsAllowed}.";

        public bool IsSatisfiedBy(EligibilityRequest entity)
        {
            var maxAllowedAccidents = EligibilityConstants.MaxAccidentsAllowed;

            return entity.AccidentCount <= maxAllowedAccidents;
        }
    }
}
