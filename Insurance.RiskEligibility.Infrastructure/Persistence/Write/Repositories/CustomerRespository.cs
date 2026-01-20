
namespace Insurance.RiskEligibility.Infrastructure.Persistence.Write.Repositories
{
    public class CustomerRespository : ICustomerRespository
    {
        private readonly RiskEligibilityDbContext _dbContext;

        public CustomerRespository(RiskEligibilityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Customer customer)
        {
            _dbContext.Customer.Update(customer);
        }
    }
}
