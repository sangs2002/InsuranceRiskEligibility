namespace Insurance.RiskEligibility.Application.Common
{
    internal static class AgeCalculator
    {
        public static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.UtcNow;
            int age = dateOfBirth.Year - today.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
