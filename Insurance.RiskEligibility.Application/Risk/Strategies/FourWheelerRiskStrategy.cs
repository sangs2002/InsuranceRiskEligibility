namespace Insurance.RiskEligibility.Application.Risk.Strategies
{
    public class FourWheelerRiskStrategy : IRiskCalculationStrategy
    {
        public int CalculateRiskScore(EligibilityRequest request)
        {
            int Score = 0;

            Score += AgeCalculator.CalculateAge(request.DateOfBirth) < RiskConstants.FourWheelerPolicy.YoungAgeThreshold ? RiskConstants.FourWheelerPolicy.YoungDriverRiskScore : RiskConstants.FourWheelerPolicy.ExperiencedRiskScore;
            Score += request.DrivingExperience < RiskConstants.FourWheelerPolicy.LowExperienceThreshold ? RiskConstants.FourWheelerPolicy.LowExperienceRiskScore : RiskConstants.FourWheelerPolicy.ExperiencedRiskScore; ;
            Score += request.AccidentCount * RiskConstants.FourWheelerPolicy.AccidentRiskMultiplier; ;

            return Score;


        }
    }
}