namespace Insurance.RiskEligibility.Application.Queries
{
    public class RiskTierQuery : IRequest<IEnumerable<RiskProfileResponse>>
    {
        public int CustomerId { get; set; }
    }
}
