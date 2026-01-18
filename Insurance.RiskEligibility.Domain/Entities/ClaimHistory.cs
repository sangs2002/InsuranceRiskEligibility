namespace Insurance.RiskEligibility.Domain.Entities
{
    public class ClaimHistory
    {
        public int ClaimId { get; private set; }
        public int CustomerId { get; private set; }
        public int PolicyId { get; private set; }
        public DateTime AccidentDate { get; private set; }
        public decimal ClaimAmount { get; private set; }
        public Customer Customer { get; private set; }
        public Policy Policy { get; private set; }


        public ClaimHistory(int claimId,int customerId,int policyId,DateTime accidentDate,decimal claimAmount)
        {
            if (claimAmount <= 0)
                throw new ArgumentException("Claim amount must be positive.");

            if (accidentDate > DateTime.UtcNow)
                throw new ArgumentException("Accident date cannot be in the future.");

            ClaimId = claimId;
            CustomerId = customerId;
            PolicyId = policyId;
            AccidentDate = accidentDate;
            ClaimAmount = claimAmount;
        }

        public bool IsRecentClaim(int years)
        {
            return AccidentDate >= DateTime.UtcNow.AddYears(-years);
        }
    }

}
