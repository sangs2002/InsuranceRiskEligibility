namespace Insurance.RiskEligibility.Domain.Constants
{
    public static class RiskConstants
    {

        public static class TwoWheelerPolicy
        {
            public const int YoungAgeThreshold = 25;

            public const int YoungRiderRiskScore = 30;
            public const int ExperiencedRiderRiskScore = 10;

            public const int LowExperienceThreshold = 3;
            public const int LowExperienceRiskScore = 15;
            public const int ExperiencedRiskScore = 5;

            public const int AccidentRiskMultiplier = 20;
        }

        public static class FourWheelerPolicy
        {
            public const int YoungAgeThreshold = 30;
            public const int YoungDriverRiskScore = 25;
            public const int ExperiencedDriverRiskScore = 10;
            public const int LowExperienceThreshold = 5;
            public const int LowExperienceRiskScore = 20;
            public const int ExperiencedRiskScore = 5;
            public const int AccidentRiskMultiplier = 25;
        }

        public static class RiskTierThresholds
        {
            public const int LowRiskMaxScore = 30;
            public const int MediumRiskMaxScore = 65;
        }

    }
}
