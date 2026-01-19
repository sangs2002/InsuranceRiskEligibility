
namespace Insurance.RiskEligibility.Infrastructure.Persistence.Write.Repositories
{
    public class CustomerRespository : ICustomerRespository
    {
        private readonly RiskEligibilityDbContext _dbContext;

        public CustomerRespository(RiskEligibilityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            var result = await _dbContext.Customer.Include(c=> c.RiskProfile)
                                           .Include(c => c.Claims)
                                           .Include(c => c.Policies)
                                           .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            return result;
        }

        public void Update(Customer customer)
        {
            _dbContext.Customer.Update(customer);
        }
    }
}
