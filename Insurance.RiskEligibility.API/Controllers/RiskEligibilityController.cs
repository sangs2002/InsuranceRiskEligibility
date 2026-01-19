namespace Insurance.RiskEligibility.API.Controllers
{
    [Route("risk")]
    [ApiController]
    public class RiskEligibilityController : ControllerBase
    {

        private readonly IRiskEvaluationCommandService _riskEvaluationCommadService;
        private readonly IRiskEvaluationQueryService _riskEvaluationQueryService;


        public RiskEligibilityController(IRiskEvaluationCommandService riskEvaluationCommandService, IRiskEvaluationQueryService riskEvaluationQueryService)
        {
            _riskEvaluationCommadService = riskEvaluationCommandService ?? throw new ArgumentNullException(nameof(riskEvaluationCommandService));
            _riskEvaluationQueryService = riskEvaluationQueryService ?? throw new ArgumentException(nameof(riskEvaluationQueryService));
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateAsync([FromBody] EligibilityRequest request)
        {
            var result = await _riskEvaluationCommadService.EvaluateAsync(request);

            return Ok(new RiskEligibilityResponse
            {
                CustomerId = request.CustomerId,
                IsEligible = result.IsEligible,
                RiskScore = result.RiskScore,
                PolicyType = result.PolicyType,
                RiskTier = result.RiskTier
            });
        }

        [HttpGet("tiers")]

        public async Task<IActionResult> GetTierAsync()
        {
            var result = await _riskEvaluationQueryService.GetAllAsync();
            return Ok(result);
        }
    }
}
