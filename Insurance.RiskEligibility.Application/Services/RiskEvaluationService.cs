namespace Insurance.RiskEligibility.Application.Services
{
    public class RiskEvaluationService : IRiskEvaluationService
    {
        private readonly IRiskTierResolver _riskTierResolver;
        private readonly IRiskCalculationStrategy _riskScoreCalculator;
        private readonly IRiskStrategyFactory _riskStrategyFactory;
        private readonly IEligibilityValidationService _eligibilityValidationService;

        public RiskEvaluationService(IRiskTierResolver riskTierResolver, IRiskCalculationStrategy riskCalculationStrategy, IRiskStrategyFactory riskStrategyFactory, IEligibilityValidationService eligibilityValidationService)
        {
            _riskTierResolver = riskTierResolver;
            _riskStrategyFactory = riskStrategyFactory;
            _eligibilityValidationService = eligibilityValidationService;
            _riskScoreCalculator = riskCalculationStrategy;
        }


        public RiskEvaluationResult Evaluate(EligibilityRequest request)
        {
            var validationResult = _eligibilityValidationService.Validate(request);

            if (!validationResult.IsValid)
            {
                return RiskEvaluationResult.NotEligible(validationResult.Errors);
            }

            var strategy = _riskStrategyFactory.GetStrategy(request.PolicyType);
            var score = _riskScoreCalculator.CalculateRiskScore(request);
            var tier = _riskTierResolver.Resolve(score);

            return RiskEvaluationResult.Eligible(score, tier);
        }
    }
}