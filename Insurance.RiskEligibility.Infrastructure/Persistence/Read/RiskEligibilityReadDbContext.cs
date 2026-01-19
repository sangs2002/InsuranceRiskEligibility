namespace Insurance.RiskEligibility.Infrastructure.Persistence
{
    public partial class RiskEligibilityDbContext : IRiskReadDbContext
    {
        public IQueryable<Customer?> Customers => Customer.AsNoTracking();

    }
}
