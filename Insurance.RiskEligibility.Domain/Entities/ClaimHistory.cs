namespace Insurance.RiskEligibility.Domain.Entities
{
    public class ClaimHistory
    {
        public int ClaimId { get; private set; }
        public int PolicyId { get; private set; }
        public DateTime AccidentDate { get; private set; }


        public ClaimHistory(int claimId,int policyId,DateTime accidentDate)
        {

            if (accidentDate > DateTime.UtcNow)
                throw new ArgumentException("Accident date cannot be in the future.");

            ClaimId = claimId;
            PolicyId = policyId;
            AccidentDate = accidentDate;
        }
    }

}
