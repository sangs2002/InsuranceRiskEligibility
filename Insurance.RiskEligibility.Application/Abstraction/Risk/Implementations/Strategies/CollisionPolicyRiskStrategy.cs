namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.Strategies
{
    public class CollisionPolicyRiskStrategy: IRiskCalculationStrategy
    {
        public PolicyType PolicyType => PolicyType.Comprehensive;

        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = AgeCalculator.CalculateAge(request.DateOfBirth);

            score += age < RiskConstants.CollisionPolicy.YoungAge
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
