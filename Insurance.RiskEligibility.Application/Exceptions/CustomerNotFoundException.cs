namespace Insurance.RiskEligibility.Application.Exceptions
{
    public sealed class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(int customerId)
           : base($"Customer with id {customerId} was not found.")
        {
        }
    }
}
