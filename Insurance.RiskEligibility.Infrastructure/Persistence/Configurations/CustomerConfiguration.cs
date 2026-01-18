namespace Insurance.RiskEligibility.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
           builder.HasKey(c=>c.CustomerId);

            builder.HasMany<ClaimHistory>("_claims")
                   .WithOne(c => c.Customer)
                   .HasForeignKey(c => c.CustomerId);

            builder.HasMany<Policy>("_policies")
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId);

            builder.HasOne(c => c.RiskProfile)
                   .WithOne(r => r.Customer)
                   .HasForeignKey<RiskProfile>(r => r.CustomerId);
        }
    }
}
