namespace Insurance.RiskEligibility.Infrastructure.Persistence.Configurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(p => p.PolicyId);

            builder.Property(p => p.PolicyNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.CoverageAmount)
                   .HasPrecision(18, 2);

            builder.Property(p => p.PremiumAmount)
                   .HasPrecision(18, 2);

            builder.Property(p => p.PolicyType)
                   .HasConversion<int>();
        }
    }
}
