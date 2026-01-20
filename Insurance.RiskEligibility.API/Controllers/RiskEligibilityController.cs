namespace Insurance.RiskEligibility.API.Controllers
{
    [Route("risk")]
    [ApiController]
    public class RiskEligibilityController : ControllerBase
    {

        private readonly IRiskCommandService _riskCommadService;
        private readonly IRiskQueryService _riskQueryService;


        public RiskEligibilityController(IRiskCommandService riskcommandService, IRiskQueryService riskqueryservice)
        {
            _riskCommadService = riskcommandService ?? throw new ArgumentNullException(nameof(riskcommandService));
            _riskQueryService = riskqueryservice ?? throw new ArgumentException(nameof(riskqueryservice));
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateAsync([FromBody] EligibilityRequest request)
        {
            var result = await _riskCommadService.EvaluateAsync(request);

            return Ok(new RiskEligibilityResponse
            {
                IsEligible = result.IsEligible,
                RiskScore = result.RiskScore,
                PolicyType = result.PolicyType,
                RiskTier = result.RiskTier
            });
        }

        [HttpGet("tiers")]

        public async Task<IActionResult> GetTierAsync()
        {
            var result = await _riskQueryService.GetAllAsync();
            return Ok(result);
        }
    }
}
