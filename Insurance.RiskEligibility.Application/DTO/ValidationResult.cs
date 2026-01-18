namespace Insurance.RiskEligibility.Application.DTO
{
    public class ValidationResult
    {
       public bool IsValid { get; }
        public IReadOnlyCollection<string> Errors { get; }


        public ValidationResult(bool isvalid, IReadOnlyCollection<string> errors)
        {
            Errors = errors.ToList().AsReadOnly();
            IsValid = isvalid;
        }


        public static ValidationResult Success()
        {
            return new ValidationResult(true, Array.Empty<string>());
        }

        public static ValidationResult Failure(IReadOnlyCollection<string> errors)
        {
            return new ValidationResult(false,errors);
        }
    }
}
