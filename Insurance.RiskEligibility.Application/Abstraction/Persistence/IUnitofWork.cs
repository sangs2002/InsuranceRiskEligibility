namespace Insurance.RiskEligibility.Application.Abstraction.Persistence
{
    public interface IUnitofWork
    {
        Task CommitAsync();
    }
}
