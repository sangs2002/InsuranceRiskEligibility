namespace Insurance.RiskEligibility.Application.Queries
{
    public class RiskTierHandler : IRequestHandler<RiskTierQuery, IEnumerable<RiskProfileResponse>>
    {
        private readonly IRiskReadDbContext _riskEligibilityDbContext;

        public RiskTierHandler(IRiskReadDbContext riskEligibilityDbContext)
        {
            _riskEligibilityDbContext = riskEligibilityDbContext;
        }
        public async Task<IEnumerable<RiskProfileResponse>> Handle(RiskTierQuery request, CancellationToken cancellationToken)
        {
                        return await _riskEligibilityDbContext.Customers
              .Where(c => c.RiskProfile != null)
              .Select(c => new RiskProfileResponse
              {
                  CustomerId = c.CustomerId,
                  RiskScore = c.RiskProfile!.RiskScore,
                  RiskTier = c.RiskProfile!.RiskTier,
              })
              .ToListAsync(cancellationToken);
        }
    }
}
