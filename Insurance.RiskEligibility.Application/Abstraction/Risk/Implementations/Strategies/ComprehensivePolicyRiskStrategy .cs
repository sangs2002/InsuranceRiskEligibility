namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.Strategies
{
    public class ComprehensivePolicyRiskStrategy : IRiskCalculationStrategy
    {
        public PolicyType PolicyType => PolicyType.Comprehensive;
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = request.Age;

            score += age < RiskConstants.ComprehensivePolicy.YoungAge
                ? RiskConstants.ComprehensivePolicy.YoungDriverRiskScore
                : RiskConstants.ComprehensivePolicy.ExperiencedRiskScore;

            score += request.DrivingExperience < RiskConstants.ComprehensivePolicy.LowExperienceThreshold
                ? RiskConstants.ComprehensivePolicy.LowExperienceRiskScore
                : RiskConstants.ComprehensivePolicy.ExperiencedRiskScore;

            score += request.AccidentCount *
                     RiskConstants.ComprehensivePolicy.AccidentRiskMultiplier;

            return score;

        }
    }
}