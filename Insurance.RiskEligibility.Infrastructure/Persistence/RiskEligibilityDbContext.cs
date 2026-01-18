namespace Insurance.RiskEligibility.Infrastructure.Persistence
{
    public class RiskEligibilityDbContext : DbContext
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
            // =========================
            // Customer
            // =========================
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.PhoneNumber)
                      .HasMaxLength(20);

                entity.Property(c => c.Occupation)
                      .HasMaxLength(100);

                entity.Property(c => c.AnnualIncome)
                      .HasPrecision(18, 2);

                // Customer → Claims (CASCADE OK)
                entity.HasMany(c => c.Claims)
                      .WithOne(c => c.Customer)
                      .HasForeignKey(c => c.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(c => c.Claims)
                      .UsePropertyAccessMode(PropertyAccessMode.Field);

                // Customer → Policies (CASCADE OK)
                entity.HasMany(c => c.Policies)
                      .WithOne(p => p.Customer)
                      .HasForeignKey(p => p.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(c => c.Policies)
                      .UsePropertyAccessMode(PropertyAccessMode.Field);

                // Customer → RiskProfile (1–1)
                entity.HasOne(c => c.RiskProfile)
                      .WithOne(r => r.Customer)
                      .HasForeignKey<RiskProfile>(r => r.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // RiskProfile
            // =========================
            modelBuilder.Entity<RiskProfile>(entity =>
            {
                entity.HasKey(r => r.RiskProfileId);

                entity.Property(r => r.RiskScore)
                      .IsRequired();

                entity.Property(r => r.RiskTier)
                      .HasConversion<int>();

                entity.Property(r => r.AssessedBy)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(r => r.AssessedOn)
                      .IsRequired();
            });

            // =========================
            // Policy
            // =========================
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

                entity.Property(p => p.PremiumAmount)
                      .HasPrecision(18, 2);

                entity.Property(p => p.StartDate)
                      .IsRequired();

                entity.Property(p => p.EndDate)
                      .IsRequired();

                entity.HasMany(p => p.Claims)
       .WithOne(c => c.Policy)
       .HasForeignKey(c => c.PolicyId)
       .OnDelete(DeleteBehavior.NoAction);

                entity.Navigation(p => p.Claims)
                      .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            // =========================
            // ClaimHistory
            // =========================
            modelBuilder.Entity<ClaimHistory>(entity =>
            {
                entity.HasKey(c => c.ClaimId);

                entity.Property(c => c.ClaimAmount)
                      .HasPrecision(18, 2);

                entity.Property(c => c.AccidentDate)
                      .IsRequired();

                // Claim → Customer (CASCADE is fine)
                entity.HasOne(c => c.Customer)
                      .WithMany(c => c.Claims)
                      .HasForeignKey(c => c.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

            });

            base.OnModelCreating(modelBuilder);
        }
   
}
}