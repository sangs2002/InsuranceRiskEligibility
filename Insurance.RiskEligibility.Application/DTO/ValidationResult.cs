namespace Insurance.RiskEligibility.Application.DTO
{
    public class ValidationResult
    {
       public bool IsValid { get; }
        public List<string> Errors { get; }


        public ValidationResult(bool isvalid, List<string> errors)
        {
            Errors = errors;
            IsValid = isvalid;
        }


        public static ValidationResult Success()
        {
            return new ValidationResult(true, new List<string>());
        }

        public static ValidationResult Failure(List<string> errors)
        {
            return new ValidationResult(false,errors);
        }
    }
}
