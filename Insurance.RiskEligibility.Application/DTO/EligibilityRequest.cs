namespace Insurance.RiskEligibility.Application.DTO
{
    public class EligibilityRequest
    {
        public int CustomerId { get; set; }
        public DateOnly DateOfBirth { get; }
        public int DrivingExperience { get; }
        public PolicyType PolicyType { get; }
        public int AccidentCount { get; }


        public EligibilityRequest(DateOnly dateOfBirth, int drivingExperience, PolicyType policyType, int accidentCount)
        {
            DateOfBirth = dateOfBirth;
            DrivingExperience = drivingExperience;
            PolicyType = policyType;
            AccidentCount = accidentCount;
        }
    }
}
