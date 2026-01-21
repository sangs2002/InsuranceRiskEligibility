namespace Insurance.RiskEligibility.Application.DTO
{
    public class EligibilityRequest
    {
        public int Age { get; set; }
        public int DrivingExperience { get; set; }
        public PolicyType PolicyType { get; set; }
        public int AccidentCount { get; set; }


        public EligibilityRequest(int age, int drivingExperience, PolicyType policyType, int accidentCount)
        {
            Age = age;
            DrivingExperience = drivingExperience;
            PolicyType = policyType;
            AccidentCount = accidentCount;
        }
    }
}
