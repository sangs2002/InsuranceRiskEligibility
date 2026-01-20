namespace Insurance.RiskEligibility.Domain.Entities
{
    public class RiskProfile
    {
        public int RiskProfileId { get; private set; }
        public int CustomerId { get; private set; }
        public int RiskScore { get; private set; }
        public RiskTier RiskTier { get; private set; }


        public RiskProfile(int customerId, int riskScore)
        {
            if (riskScore < 0 || riskScore > 100)
                throw new ArgumentException("Risk score must be between 0 and 100.");

            CustomerId = customerId;
            RiskScore = riskScore;

        }
    }

}
