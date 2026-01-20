namespace Insurance.RiskEligibility.Application.Specification
{
    public class DrivingExperienceSpecification : ISpecification<EligibilityRequest>
    {
        public string ErrorMessage =>
               $"Driving experience must be between {EligibilityConstants.MinDrivingExperience} " + $"and applicant age.";

        public bool IsValid(EligibilityRequest entity)
        {
            var MinExperience = EligibilityConstants.MinDrivingExperience;
            var MaxExperience = AgeCalculator.CalculateAge(entity.DateOfBirth);

            return entity.DrivingExperience >= MinExperience &&
                   entity.DrivingExperience <= MaxExperience;
        }
    }
}
