namespace Insurance.RiskEligibility.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public int DrivingExperience { get; private set; }
        public RiskProfile RiskProfile { get; private set; }

        public Customer(int customerId,string name,DateOnly dateOfBirth, int drivingExperience)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            if (dateOfBirth >= today)
                throw new ArgumentException("Date of birth must be in the past.");

            if (drivingExperience < 0)
                throw new ArgumentException("Driving experience cannot be negative.");

            CustomerId = customerId;
            Name = name;
            DateOfBirth = dateOfBirth;
            DrivingExperience = drivingExperience;
        }

    }

}
