namespace Insurance.RiskEligibility.Domain.Constants
{
    public static class RiskConstants
    {

        public static class ComprehensivePolicy
        {
            public const int YoungAgeThreshold = 25;
            public const int YoungDriverRiskScore = 30;
            public const int ExperiencedRiskScore = 10;

            public const int LowExperienceThreshold = 5;
            public const int LowExperienceRiskScore = 20;

            public const int AccidentRiskMultiplier = 20;
        }

        public static class ThirdPartyPolicy
        {
            public const int YoungAgeThreshold = 25;
            public const int YoungDriverRiskScore = 15;
            public const int ExperiencedRiskScore = 5;

            public const int LowExperienceThreshold = 3;
            public const int LowExperienceRiskScore = 10;

            public const int AccidentRiskMultiplier = 10;
        }

        public static class CollisionPolicy
        {
            public const int YoungAgeThreshold = 25;
            public const int YoungDriverRiskScore = 20;
            public const int ExperiencedRiskScore = 8;

            public const int LowExperienceThreshold = 4;
            public const int LowExperienceRiskScore = 15;

            public const int AccidentRiskMultiplier = 15;
        }

        public static class RiskTierThresholds
        {
            public const int LowRiskMaxScore = 30;
            public const int MediumRiskMaxScore = 65;
        }

    }
}
