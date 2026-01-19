using Insurance.RiskEligibility.Application.Abstraction.Risk;

namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Strategies
{
    public class ComprehensivePolicyRiskStrategy : IRiskCalculationStrategy
    {
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = AgeCalculator.CalculateAge(request.DateOfBirth);

            score += age < RiskConstants.ComprehensivePolicy.YoungAgeThreshold
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