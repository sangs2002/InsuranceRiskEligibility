namespace Insurance.RiskEligibility.Infrastructure.Persistence.Configurations
{
    public class ClaimHistoryConfiguration : IEntityTypeConfiguration<ClaimHistory>
    {
        public void Configure(EntityTypeBuilder<ClaimHistory> builder)
        {
            builder.HasKey(c => c.ClaimId);

            builder.Property(c => c.ClaimAmount)
                   .HasPrecision(18, 2);
        }
    }
}
