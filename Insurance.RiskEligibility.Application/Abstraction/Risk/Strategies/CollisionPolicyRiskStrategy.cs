namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Strategies
{
    public class CollisionPolicyRiskStrategy: IRiskCalculationStrategy
    {
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = AgeCalculator.CalculateAge(request.DateOfBirth);

            score += age < RiskConstants.CollisionPolicy.YoungAgeThreshold
                ? RiskConstants.CollisionPolicy.YoungDriverRiskScore
                : RiskConstants.CollisionPolicy.ExperiencedRiskScore;

            score += request.DrivingExperience < RiskConstants.CollisionPolicy.LowExperienceThreshold
                ? RiskConstants.CollisionPolicy.LowExperienceRiskScore
                : RiskConstants.CollisionPolicy.ExperiencedRiskScore;

            score += request.AccidentCount *
                     RiskConstants.CollisionPolicy.AccidentRiskMultiplier;

            return score;
        }
    }
}
