namespace Insurance.RiskEligibility.Application.Queries
{
    public class RiskQueryService : IRiskQueryService
    {

        private readonly IRiskReadDbContext _riskEligibilityDbContext;

        public RiskQueryService(IRiskReadDbContext riskEligibilityDbContext)
        {
            _riskEligibilityDbContext = riskEligibilityDbContext;
        }
        public async Task<List<RiskProfileResponse>> GetAllAsync()
        {
            return await _riskEligibilityDbContext.Customers
             .Where(c => c.RiskProfile != null)
             .Select(c => new RiskProfileResponse
             {
                 CustomerId = c.CustomerId,
                 RiskScore = c.RiskProfile!.RiskScore,
                 RiskTier = c.RiskProfile!.RiskTier,
             })
             .ToListAsync();
        }
    }
}
