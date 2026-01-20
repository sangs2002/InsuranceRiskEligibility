using Insurance.RiskEligibility.Application.Abstraction.Risk.Interface;

namespace Insurance.RiskEligibility.Application.Command
{
    public class RiskEvaluationCommandService : IRiskCommandService
    {
        private readonly IRiskTier _riskTier;
        private readonly IRiskStrategyFactory _riskStrategyFactory;
        private readonly IEligibilityValidationService _eligibilityValidationService;
        private readonly IUnitofWork _unitofWork;

        public RiskEvaluationCommandService(ICustomerRespository customerRespository, IRiskTier riskTier, IRiskStrategyFactory riskStrategyFactory, IEligibilityValidationService eligibilityValidationService, IUnitofWork unitofWork)
        {
            _riskTier = riskTier;
            _riskStrategyFactory = riskStrategyFactory;
            _eligibilityValidationService = eligibilityValidationService;
            _unitofWork = unitofWork;
        }


        public async Task<RiskEvaluationResult> EvaluateAsync(EligibilityRequest request)
        {

            var validationResult = _eligibilityValidationService.Validate(request);
            if (!validationResult.IsValid)
            {
                return RiskEvaluationResult.NotEligible(validationResult.Errors);
            }

            var strategy = _riskStrategyFactory.GetStrategy(request.PolicyType);

            var score = strategy.CalculateRiskScore(request);
            var tier = _riskTier.Tier(score);

            await _unitofWork.CommitAsync();


            return RiskEvaluationResult.Eligible(score, tier, request.PolicyType);


        }
    }
}