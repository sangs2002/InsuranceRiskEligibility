namespace Insurance.RiskEligibility.Application.Abstraction.Persistence
{
    public interface ICustomerRespository
    {
        Task<Customer?> GetByIdAsync(int customerId);
        void Update(Customer customer);
    }
}
