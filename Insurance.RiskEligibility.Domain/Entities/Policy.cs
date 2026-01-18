namespace Insurance.RiskEligibility.Domain.Entities
{
    public class Policy
    {
        public int PolicyId { get; private set; }
        public string PolicyNumber { get; private set; }
        public PolicyType PolicyType { get; private set; }
        public decimal CoverageAmount { get; private set; }
        public decimal PremiumAmount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        private readonly List<ClaimHistory> _claims = new();
        public IReadOnlyCollection<ClaimHistory> Claims => _claims;


        public Policy(int policyId,string policyNumber,PolicyType policyType,decimal coverageAmount,decimal premiumAmount,DateTime startDate,DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("Policy end date must be after start date.");

            if (coverageAmount <= 0)
                throw new ArgumentException("Coverage amount must be positive.");

            PolicyId = policyId;
            PolicyNumber = policyNumber ?? throw new ArgumentNullException(nameof(policyNumber));
            PolicyType = policyType;
            CoverageAmount = coverageAmount;
            PremiumAmount = premiumAmount;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsActive(DateTime onDate)
        {
            return onDate >= StartDate && onDate <= EndDate;
        }
    }

}
