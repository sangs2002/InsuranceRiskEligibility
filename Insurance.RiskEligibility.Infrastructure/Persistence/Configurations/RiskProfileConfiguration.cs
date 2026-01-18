namespace Insurance.RiskEligibility.Infrastructure.Persistence.Configurations
{
    public class RiskProfileConfiguration : IEntityTypeConfiguration<RiskProfile>
    {
        public void Configure(EntityTypeBuilder<RiskProfile> builder)
        {
            builder.HasKey(r => r.RiskProfileId);

            builder.Property(r => r.RiskScore)
                   .IsRequired();

            builder.Property(r => r.RiskTier)
                   .HasConversion<int>();

            builder.Property(r => r.AssessedBy)
                   .HasMaxLength(100);
        }
    }
}
