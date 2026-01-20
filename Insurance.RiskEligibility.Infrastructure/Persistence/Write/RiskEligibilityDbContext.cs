namespace Insurance.RiskEligibility.Infrastructure.Persistence
{
    public partial class RiskEligibilityDbContext : DbContext
    {

        public RiskEligibilityDbContext(DbContextOptions<RiskEligibilityDbContext> options)
               : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<RiskProfile> RiskProfile { get; set; }
        public DbSet<ClaimHistory> ClaimHistory { get; set; }
        public DbSet<Policy> Policy { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

            });
            modelBuilder.Entity<RiskProfile>(entity =>
            {
                entity.HasKey(r => r.RiskProfileId);

                entity.Property(r => r.RiskScore)
                      .IsRequired();

                entity.Property(r => r.RiskTier)
                      .HasConversion<int>();

            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(p => p.PolicyId);

                entity.Property(p => p.PolicyNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.PolicyType)
                      .HasConversion<int>();

                entity.Property(p => p.CoverageAmount)
                      .HasPrecision(18, 2);


                modelBuilder.Entity<ClaimHistory>(entity =>
                {
                    entity.HasKey(c => c.ClaimId);

                    entity.Property(c => c.AccidentDate)
                          .IsRequired();

                });

                base.OnModelCreating(modelBuilder);
            });


}
    }
}
