namespace Insurance.RiskEligibility.Domain.Models
{
    public class RiskEligibilityResponse
    {
        public bool IsEligible { get; set; }
        public int? RiskScore { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PolicyType? PolicyType { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RiskTier? RiskTier { get; set; } 

    }
}
