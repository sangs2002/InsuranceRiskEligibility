namespace Insurance.RiskEligibility.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly RiskEligibilityDbContext _dbContext;

        public UnitOfWork(RiskEligibilityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
