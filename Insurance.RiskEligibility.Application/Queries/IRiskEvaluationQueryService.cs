namespace Insurance.RiskEligibility.Application.Queries
{
    public interface IRiskEvaluationQueryService
    {
        Task<IReadOnlyList<RiskProfileReadDto>> GetAllAsync();
    }
}
