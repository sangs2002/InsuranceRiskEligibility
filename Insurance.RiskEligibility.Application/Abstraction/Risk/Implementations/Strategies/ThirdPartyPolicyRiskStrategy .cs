namespace Insurance.RiskEligibility.Application.Abstraction.Risk.Implementations.Strategies
{
    public class ThirdPartyPolicyRiskStrategy : IRiskCalculationStrategy
    {
        public PolicyType PolicyType => PolicyType.ThirdParty;
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int score = 0;
            int age = request.Age;

            score += age < RiskConstants.ThirdPartyPolicy.YoungAge
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
