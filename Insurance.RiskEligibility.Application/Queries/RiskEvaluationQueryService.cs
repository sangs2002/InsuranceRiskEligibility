namespace Insurance.RiskEligibility.Application.Queries
{
    public class RiskEvaluationQueryService : IRiskEvaluationQueryService
    {

        private readonly IRiskReadDbContext _riskEligibilityDbContext;

        public RiskEvaluationQueryService(IRiskReadDbContext riskEligibilityDbContext)
        {
            _riskEligibilityDbContext = riskEligibilityDbContext;
        }
        public async Task<IReadOnlyList<RiskProfileReadDto>> GetAllAsync()
        {
            return await _riskEligibilityDbContext.Customers
             .Where(c => c.RiskProfile != null)
             .Select(c => new RiskProfileReadDto
             {
                 CustomerId = c.CustomerId,
                 RiskScore = c.RiskProfile!.RiskScore,
                 RiskTier = c.RiskProfile!.RiskTier,
             })
             .ToListAsync();
        }
    }
}
