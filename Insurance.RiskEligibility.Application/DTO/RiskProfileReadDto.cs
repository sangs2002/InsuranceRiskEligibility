namespace Insurance.RiskEligibility.Application.DTO
{
    public class RiskProfileReadDto
    {
        public int CustomerId { get; set; }
        public int RiskScore { get; set; }
        public RiskTier RiskTier { get; set; }
    }
}
