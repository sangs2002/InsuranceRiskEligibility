namespace Insurance.RiskEligibility.Domain.Entities
{
    public class Policy
    {
        public int PolicyId { get; private set; }
        public string PolicyNumber { get; private set; }
        public PolicyType PolicyType { get; private set; }
        public decimal CoverageAmount { get; private set; }


        public Policy(int policyId,string policyNumber,PolicyType policyType,decimal coverageAmount)
        {

            if (coverageAmount <= 0)
                throw new ArgumentException("Coverage amount must be positive.");

            PolicyId = policyId;
            PolicyNumber = policyNumber ?? throw new ArgumentNullException(nameof(policyNumber));
            PolicyType = policyType;
            CoverageAmount = coverageAmount;
            
        }

    }

}
