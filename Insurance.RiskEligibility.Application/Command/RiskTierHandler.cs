namespace Insurance.RiskEligibility.Application.Command
{
    public class RiskTierHandler : IRequestHandler<RiskTierCommand, RiskEvaluationResult>
    {

        private readonly IRiskTier _riskTier;
        private readonly IRiskStrategyFactory _riskStrategyFactory;
        private readonly IEligibilityValidationService _eligibilityValidationService;
        private readonly IUnitofWork _unitofWork;

        public RiskTierHandler(ICustomerRespository customerRespository, IRiskTier riskTier, IRiskStrategyFactory riskStrategyFactory, IEligibilityValidationService eligibilityValidationService, IUnitofWork unitofWork)
        {
            _riskTier = riskTier;
            _riskStrategyFactory = riskStrategyFactory;
            _eligibilityValidationService = eligibilityValidationService;
            _unitofWork = unitofWork;
        }
        public async Task<RiskEvaluationResult> Handle(RiskTierCommand command, CancellationToken cancellationToken)
        {
            var request = new EligibilityRequest(
                command.age,
                command.DrivingExperience,
                command.PolicyType,
                command.AccidentCount
            );

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
