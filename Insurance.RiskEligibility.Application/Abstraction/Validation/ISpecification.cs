namespace Insurance.RiskEligibility.Application.Abstraction.Validation
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        string ErrorMessage { get; }
    }
}
