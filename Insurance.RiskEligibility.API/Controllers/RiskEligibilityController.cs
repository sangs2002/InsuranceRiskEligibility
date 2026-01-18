using Azure.Core;

namespace Insurance.RiskEligibility.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskEligibilityController : ControllerBase
    {

        private readonly IRiskEvaluationService _riskEvaluationService;

        public RiskEligibilityController(RiskEvaluationService riskEvaluationService)
        {
            _riskEvaluationService = riskEvaluationService ?? throw new ArgumentNullException(nameof(RiskEvaluationService));
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateAsync([FromBody] EligibilityRequest eligibilityRequest)
        {
            if (eligibilityRequest is null)
            {
                return BadRequest("Eligibility request must not be null.");
            }

            var result = await _riskEvaluationService.Evaluate(eligibilityRequest);

            if (!result.IsEligible)
            {
                return UnprocessableEntity(result);
            }

            return Ok(result);
        }
    }
}
