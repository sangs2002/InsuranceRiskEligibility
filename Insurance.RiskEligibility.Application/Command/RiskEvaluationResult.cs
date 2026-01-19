namespace Insurance.RiskEligibility.Domain.Models
{
    public class RiskEvaluationResult
    {
        public int customerId { get; init; }
        public bool IsEligible { get; }
        public int? RiskScore { get; }
        public RiskTier? RiskTier { get; }
        public PolicyType? PolicyType { get; init; }
        public IReadOnlyCollection<string> Errors { get; }

        private RiskEvaluationResult(
            bool isEligible,
            int? riskScore,
            RiskTier? riskTier,
            PolicyType? policyType,
            IReadOnlyCollection<string> errors)
        {
            IsEligible = isEligible;
            RiskScore = riskScore;
            RiskTier = riskTier;
            PolicyType = policyType;
            Errors = errors;

        }

        public static RiskEvaluationResult NotEligible(IEnumerable<string> errors)
        {
            if (errors == null)
                throw new ArgumentNullException(nameof(errors));

            return new RiskEvaluationResult(
                isEligible: false,
                riskScore: null,
                riskTier: null,
                policyType: null,
                errors: errors.ToList().AsReadOnly()
            );
        }

        public static RiskEvaluationResult Eligible(int score, RiskTier tier, PolicyType policyType)
        {
            return new RiskEvaluationResult(
                isEligible: true,
                riskScore: score,
                riskTier: tier,
                policyType: policyType,
                errors: Array.Empty<string>()
            );
        }
    }
}
