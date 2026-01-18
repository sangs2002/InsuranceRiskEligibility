namespace Insurance.RiskEligibility.Application.Risk.Strategies
{
    public class TwoWheelerRiskStrategy : IRiskCalculationStrategy
    {
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = AgeCalculator.CalculateAge(request.DateOfBirth);

            score += age < RiskConstants.TwoWheelerPolicy.YoungAgeThreshold
                ? RiskConstants.TwoWheelerPolicy.YoungRiderRiskScore
                : RiskConstants.TwoWheelerPolicy.ExperiencedRiderRiskScore;

            score += request.DrivingExperience < RiskConstants.TwoWheelerPolicy.LowExperienceThreshold
                ? RiskConstants.TwoWheelerPolicy.LowExperienceRiskScore
                : RiskConstants.TwoWheelerPolicy.ExperiencedRiskScore;

            score += request.AccidentCount * RiskConstants.TwoWheelerPolicy.AccidentRiskMultiplier;

            return score;
        }
    }
}
