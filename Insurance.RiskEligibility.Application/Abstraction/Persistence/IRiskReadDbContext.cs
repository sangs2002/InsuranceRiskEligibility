namespace Insurance.RiskEligibility.Application.Abstraction.Persistence
{
    public interface IRiskReadDbContext
    {
        IQueryable<Customer?> Customers { get; }

    }
}
