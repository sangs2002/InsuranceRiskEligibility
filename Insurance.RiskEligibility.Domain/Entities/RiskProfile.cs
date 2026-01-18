namespace Insurance.RiskEligibility.Domain.Entities
{
    public class RiskProfile
    {
        public int RiskProfileId { get; private set; }
        public int CustomerId { get; private set; }
        public int RiskScore { get; private set; }
        public RiskTier RiskTier { get; private set; }
        public DateTime AssessedOn { get; private set; }
        public string AssessedBy { get; private set; }
        public Customer Customer { get; private set; }


        private RiskProfile() { }

        public RiskProfile(int customerId, int riskScore, string assessedBy)
        {
            if (riskScore < 0 || riskScore > 100)
                throw new ArgumentException("Risk score must be between 0 and 100.");

            CustomerId = customerId;
            RiskScore = riskScore;
            AssessedOn = DateTime.UtcNow;
            AssessedBy = assessedBy;
        }
    }

}
