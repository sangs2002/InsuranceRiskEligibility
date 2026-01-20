namespace Insurance.RiskEligibility.Application.DTO
{
    public class EligibilityRequest
    {
        public DateOnly DateOfBirth { get; set; }
        public int DrivingExperience { get; set; }
        public PolicyType PolicyType { get; set; }
        public int AccidentCount { get; set; }


        public EligibilityRequest(DateOnly dateOfBirth, int drivingExperience, PolicyType policyType, int accidentCount)
        {
            DateOfBirth = dateOfBirth;
            DrivingExperience = drivingExperience;
            PolicyType = policyType;
            AccidentCount = accidentCount;
        }
    }
}
