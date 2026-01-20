namespace Insurance.RiskEligibility.Application.Abstraction.Validation
{
    public interface ISpecification<T>
    {
        bool IsValid(T entity);
        string ErrorMessage { get; }
    }
}
