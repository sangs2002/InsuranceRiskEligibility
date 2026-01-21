namespace Insurance.RiskEligibility.API.Controllers
{
    [ApiController]
    [Route("api/risk")]
    public class RiskEligibilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RiskEligibilityController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateAsync([FromBody] RiskTierCommand command)
        {
            var result = await _mediator.Send(command);

            var response = new RiskEligibilityResponse
            {
                IsEligible = result.IsEligible,
                RiskScore = result.RiskScore,
                PolicyType = result.PolicyType,
                RiskTier = result.RiskTier
            };

            return Ok(response);
        }

        [HttpGet("tiers")]

        public async Task<IActionResult> GetTierAsync()
        {
            var result = await _mediator.Send(new RiskTierQuery());
            return Ok(result);
        }
    }
}
