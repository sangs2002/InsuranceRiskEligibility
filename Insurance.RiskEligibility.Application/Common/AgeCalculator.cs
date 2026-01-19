namespace Insurance.RiskEligibility.Application.Common
{
    public static class AgeCalculator
    {
        public static int CalculateAge(DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            int age =  today.Year - dateOfBirth.Year ;
            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
