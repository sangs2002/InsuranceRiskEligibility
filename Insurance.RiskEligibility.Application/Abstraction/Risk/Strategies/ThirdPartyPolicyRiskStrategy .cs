using Insurance.RiskEligibility.Application.Abstraction.Risk;

namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Strategies
{
    public class ThirdPartyPolicyRiskStrategy : IRiskCalculationStrategy
    {
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = AgeCalculator.CalculateAge(request.DateOfBirth);

            score += age < RiskConstants.ThirdPartyPolicy.YoungAgeThreshold
                ? RiskConstants.ThirdPartyPolicy.YoungDriverRiskScore
                : RiskConstants.ThirdPartyPolicy.ExperiencedRiskScore;

            score += request.DrivingExperience < RiskConstants.ThirdPartyPolicy.LowExperienceThreshold
                ? RiskConstants.ThirdPartyPolicy.LowExperienceRiskScore
                : RiskConstants.ThirdPartyPolicy.ExperiencedRiskScore;

            score += request.AccidentCount *
                     RiskConstants.ThirdPartyPolicy.AccidentRiskMultiplier;

            return score;
        }
    }
}
