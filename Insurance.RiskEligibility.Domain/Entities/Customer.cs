namespace Insurance.RiskEligibility.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int DrivingExperience { get; private set; }
        public RiskProfile RiskProfile { get; private set; }

        public Customer(int customerId,string name,int age ,int drivingExperience)
        {

            if (drivingExperience < 0)
                throw new ArgumentException("Driving experience cannot be negative.");

            CustomerId = customerId;
            Name = name;
            Age = age;
            DrivingExperience = drivingExperience;
        }

    }

}
