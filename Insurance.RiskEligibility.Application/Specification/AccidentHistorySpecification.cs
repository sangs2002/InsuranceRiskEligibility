namespace Insurance.RiskEligibility.Application.Specification
{
    public class AccidentHistorySpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage => $"Accident count must not exceed {EligibilityConstants.MaxAccidentsAllowed}.";

        public bool IsValid(EligibilityRequest entity)
        {
            var maxAllowedAccidents = EligibilityConstants.MaxAccidentsAllowed;

            return entity.AccidentCount <= maxAllowedAccidents;
        }
    }
}
