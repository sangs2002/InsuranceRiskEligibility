namespace Insurance.RiskEligibility.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public int DrivingExperience { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal AnnualIncome { get; private set; }
        public string Occupation { get; private set; }
        public RiskProfile RiskProfile { get; private set; }


        private readonly List<ClaimHistory> _claims = new();
        private readonly List<Policy> _policies = new();

        public IReadOnlyCollection<ClaimHistory> Claims => _claims;
        public IReadOnlyCollection<Policy> Policies => _policies;

        private Customer() { }

        public Customer(int customerId,string firstName,string lastName,DateOnly dateOfBirth, int drivingExperience, string phoneNumber,decimal annualIncome,string occupation)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            if (dateOfBirth >= today)
                throw new ArgumentException("Date of birth must be in the past.");

            if (drivingExperience < 0)
                throw new ArgumentException("Driving experience cannot be negative.");

            CustomerId = customerId;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            DateOfBirth = dateOfBirth;
            DrivingExperience = drivingExperience;
            PhoneNumber = phoneNumber;
            AnnualIncome = annualIncome;
            Occupation = occupation;
        }

    }

}
