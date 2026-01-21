namespace Insurance.RiskEligibility.Application.DTO
{
    public class RiskEvaluationResult
    {
        public bool IsEligible { get; }
        public int? RiskScore { get; }
        public RiskTier? RiskTier { get; }
        public PolicyType? PolicyType { get; init; }
        public List<string> Errors { get; }

        private RiskEvaluationResult( bool isEligible, int? riskScore,RiskTier? riskTier, PolicyType? policyType, List<string> errors)
        {
            IsEligible = isEligible;
            RiskScore = riskScore;
            RiskTier = riskTier;
            PolicyType = policyType;
            Errors = errors;

        }

        public static RiskEvaluationResult NotEligible(IEnumerable<string> errors)
        {

            return new RiskEvaluationResult(
                isEligible: false,
                riskScore: null,
                riskTier: null,
                policyType: null,
                errors: errors.ToList()
            );
        }

        public static RiskEvaluationResult Eligible(int score, RiskTier tier, PolicyType policyType)
        {
            return new RiskEvaluationResult(
                isEligible: true,
                riskScore: score,
                riskTier: tier,
                policyType: policyType,
                errors: null
            );
        }
    }
}
