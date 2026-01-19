namespace Insurance.RiskEligibility.Application.Command
{
    public class RiskEvaluationCommandService : IRiskEvaluationCommandService
    {
        private readonly ICustomerRespository _customerRepository;
        private readonly IRiskTierResolver _riskTierResolver;
        private readonly IRiskStrategyFactory _riskStrategyFactory;
        private readonly IEligibilityValidationService _eligibilityValidationService;
        private readonly IUnitofWork _unitofWork;

        public RiskEvaluationCommandService(ICustomerRespository customerRespository, IRiskTierResolver riskTierResolver, IRiskStrategyFactory riskStrategyFactory, IEligibilityValidationService eligibilityValidationService, IUnitofWork unitofWork)
        {
            _customerRepository = customerRespository;
            _riskTierResolver = riskTierResolver;
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

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException(request.CustomerId);
            }

            var strategy = _riskStrategyFactory.GetStrategy(request.PolicyType);

            var score = strategy.CalculateRiskScore(request);
            var tier = _riskTierResolver.Resolve(score);

            _customerRepository.Update(customer);
            await _unitofWork.CommitAsync();


            return RiskEvaluationResult.Eligible(score, tier, request.PolicyType);


        }
    }
}