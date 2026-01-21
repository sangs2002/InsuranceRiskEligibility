namespace Insurance.RiskEligibility.Application.Command
{
    public class RiskTierCommand: IRequest<RiskEvaluationResult>
    {
        public int age { get; set; }
        public int DrivingExperience { get; set; }
        public PolicyType PolicyType { get; set; }
        public int AccidentCount { get; set; }
    }
}
