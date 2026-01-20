namespace Insurance.RiskEligibility.Application.Queries
{
    public interface IRiskQueryService
    {
        Task<List<RiskProfileResponse>> GetAllAsync();
    }
}
