namespace Insurance.RiskEligibility.Domain.Models
{
    public class RiskEvaluationResult
    {
        public bool IsEligible { get; }
        public int? RiskScore { get; }
        public RiskTier? RiskTier { get; }
        public IReadOnlyCollection<string> Errors { get; }

        private RiskEvaluationResult(
            bool isEligible,
            int? riskScore,
            RiskTier? riskTier,
            IReadOnlyCollection<string> errors)
        {
            IsEligible = isEligible;
            RiskScore = riskScore;
            RiskTier = riskTier;
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
                errors: errors.ToList().AsReadOnly()
            );
        }

        public static RiskEvaluationResult Eligible(int score, RiskTier tier)
        {
            return new RiskEvaluationResult(
                isEligible: true,
                riskScore: score,
                riskTier: tier,
                errors: Array.Empty<string>()
            );
        }
    }
}
