namespace Insurance.RiskEligibility.Application.DTO
{
    public class EligibilityRequest
    {
        public DateTime DateOfBirth { get; }
        public int DrivingExperience { get; }
        public PolicyType PolicyType { get; }
        public int AccidentCount { get; }


        public EligibilityRequest(DateTime dateOfBirth, int drivingExperience, PolicyType policyType, int accidentCount)
        {
            DateOfBirth = dateOfBirth;
            DrivingExperience = drivingExperience;
            PolicyType = policyType;
            AccidentCount = accidentCount;
        }
    }
}
